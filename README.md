
# 🧩 WaStickers Extractor GUI

Aplicación de escritorio en C# (.NET 6) con WinForms para extraer imágenes `.webp` desde archivos `.wastickers` (internamente archivos `.zip` de stickers). Ideal para recuperar stickers de WhatsApp exportados.

---

## ✨ Funcionalidades

- Selecciona un archivo `.wastickers` desde tu PC.
- Se crea automáticamente una carpeta con el nombre del archivo.
- Se extraen todas las imágenes `.webp` (stickers) dentro de esa carpeta.
- Notificación visual al finalizar.
- Interfaz moderna con tema oscuro tipo Visual Studio Code.

---

## 🛠️ Tecnologías Usadas

- Lenguaje: C#
- Framework: .NET 6
- Interfaz: Windows Forms (WinForms)
- Librerías:
  - `System.IO.Compression` (para extraer archivos .zip)
  - `System.Windows.Forms` (interfaz gráfica)
  - `System.Drawing` (visualización y estilos)

---

## 💻 Requisitos

- Sistema: Windows 64-bit
- No requiere instalación de .NET (versión *self-contained*)
- Peso aprox: 107 MB

---

## 🚀 Ejecutable

Puedes descargar la última versión compilada desde la sección **[Releases](../../releases)** del repositorio.

**Nombre:** `WaStickersExtractorGUI.exe`  
**Ubicación:** Carpeta `release/` o desde la página de Releases

---

## 🧑‍💻 Ejecución manual del proyecto

```bash
dotnet run
```

## 🧪 Compilación como ejecutable

```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

---

## 🎨 Tema Oscuro Aplicado

- Fondo: `Color.FromArgb(30, 30, 30)`
- Botones: `Color.FromArgb(45, 45, 48)` con texto blanco
- Estilo visual plano (`FlatStyle.Flat`) para apariencia moderna

---

## 🧾 Créditos

Desarrollado por **Jhon** con ❤️ usando Visual Studio Code.
