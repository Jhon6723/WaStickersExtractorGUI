namespace WaStickersExtractorGUI;

using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using ImageMagick;
partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;


    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    
    private string archivoSeleccionado = "";
    private string carpetaDestino = "";
    FlowLayoutPanel panel = new FlowLayoutPanel();
    private Label lblRutaDestino;


    private void InitializeComponent()
    {
        this.Text = "WaStickers Extractor GUI";
        this.BackColor = Color.FromArgb(30, 30, 30);
        this.Size = new Size(320, 200);
        var fuenteBoton = new Font("Segoe UI", 10, FontStyle.Regular);
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        
        // Elementos
        Button btnSeleccionarArchivo = new Button() {
            Text = "Seleccionar archivo .wastickers",
            Width = 250,
            Top = 20,
            Left = 20,
            Font = fuenteBoton,
            BackColor = Color.FromArgb(45, 45, 48), // tono fondo botón
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };

        Button btnSeleccionarCarpeta = new Button() {
            Text = "Seleccionar carpeta destino",
            Width = 250,
            Top = 60,
            Left = 20,
            Font = fuenteBoton,
            BackColor = Color.FromArgb(45, 45, 48), // tono fondo botón
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };

        Button btnExtraer = new Button() {
            Text = "Extraer Stickers",
            Width = 250,
            Top = 100,
            Left = 20,
            Font = fuenteBoton,
            BackColor = Color.FromArgb(45, 45, 48), // tono fondo botón
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink

        };
        lblRutaDestino = new Label()
        {
            Text = "Ruta destino no establecida.",
            AutoSize = true,
            Font = new Font("Segoe UI", 9, FontStyle.Italic),
            BackColor = Color.FromArgb(45, 45, 48), // tono fondo botón
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(0, 10, 0, 0)
        };


        btnSeleccionarArchivo.Click += BtnSeleccionarArchivo_Click;
        btnSeleccionarCarpeta.Click += BtnSeleccionarCarpeta_Click;
        btnExtraer.Click += BtnExtraer_Click;
        this.Load += Form1_Load;

        // Magen
        panel.FlowDirection = FlowDirection.TopDown;
        panel.WrapContents = false;
        panel.Dock = DockStyle.Fill;
        panel.Padding = new Padding(0, 50, 0, 0); // margen interno
        panel.AutoSize = true;
        panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        // Centrado
        panel.Anchor = AnchorStyles.None;
        panel.Location = new Point(
            (this.ClientSize.Width - panel.PreferredSize.Width) / 2,
            (this.ClientSize.Height - panel.PreferredSize.Height) / 2
        );

        panel.Controls.Add(btnSeleccionarArchivo);
        panel.Controls.Add(btnSeleccionarCarpeta);
        panel.Controls.Add(btnExtraer);
        panel.Controls.Add(lblRutaDestino);
        this.Controls.Add(panel);
        this.Text = "Extractor de wastickers";
    }
    private void BtnSeleccionarArchivo_Click(object sender, EventArgs e)
    {
        using OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "Archivo WaStickers (*.wastickers)|*.wastickers";
        if (ofd.ShowDialog() == DialogResult.OK){
            archivoSeleccionado = ofd.FileName;
            lblRutaDestino.Text = $"Archivo seleccionado: {archivoSeleccionado}";
        }
            
    }

private void BtnSeleccionarCarpeta_Click(object sender, EventArgs e)
{
    if (string.IsNullOrEmpty(archivoSeleccionado))
    {
        MessageBox.Show("Primero debes seleccionar un archivo .wastickers.");
        return;
    }

    using FolderBrowserDialog fbd = new FolderBrowserDialog();
    if (fbd.ShowDialog() == DialogResult.OK)
    {
        try
        {
            string nombreCarpeta = Path.GetFileNameWithoutExtension(archivoSeleccionado) + "_stickers";
            carpetaDestino = Path.Combine(fbd.SelectedPath, nombreCarpeta);

            Directory.CreateDirectory(carpetaDestino);
            lblRutaDestino.Text = $"Carpeta creada: {carpetaDestino}";
            lblRutaDestino.ForeColor = Color.DarkGreen;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear la carpeta:\n{ex.Message}");
        }
    }
}




    private async void BtnExtraer_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(archivoSeleccionado) || string.IsNullOrEmpty(carpetaDestino))
        {
            MessageBox.Show("Primero debes seleccionar el archivo y la carpeta de destino.");
            return;
        }

        await Task.Run(() =>
        {
            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(archivoSeleccionado))
                {
                    int contador = 0;
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".webp", StringComparison.OrdinalIgnoreCase))
                        {
                            string destinoWebp = Path.Combine(carpetaDestino, entry.Name);
                            entry.ExtractToFile(destinoWebp, overwrite: true);

                            // Convertir a PNG
                            string destinoPng = Path.ChangeExtension(destinoWebp, ".png");
                            using var image = new MagickImage(destinoWebp);
                            image.Format = MagickFormat.Png;
                            image.Write(destinoPng);
                            File.Delete(destinoWebp);
                            contador++;

                            Invoke(() => {
                                lblRutaDestino.Text = $"Procesando archivos: \n{new string('.', contador)}";
                            });
                        }
                    }
                    
                }

                Invoke(() =>
                {
                    lblRutaDestino.ForeColor = Color.DarkGreen;
                    lblRutaDestino.Text = $"¡Extracción completada con éxito!\nDestino: {carpetaDestino}";
                    Process.Start("explorer.exe", carpetaDestino);
                });
            }
            catch (Exception ex)
            {
                Invoke(() =>
                {
                    lblRutaDestino.Text = $"Error al extraer: {ex.Message}";
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                });
            }
        });

    }
    private void Form1_Load(object sender, EventArgs e)
    {
        panel.Location = new Point(
            (this.ClientSize.Width - panel.PreferredSize.Width) / 2,
            (this.ClientSize.Height - panel.PreferredSize.Height) / 2
        );
    }

    #endregion
}
