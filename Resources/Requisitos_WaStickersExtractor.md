# Requisitos del Programa: WaStickers Extractor

## ✅ Requisitos Funcionales

1. **Importar archivo `.wastickers`**
   - El usuario podrá seleccionar un archivo `.wastickers` desde el sistema de archivos mediante un botón y un `OpenFileDialog`.

2. **Extraer contenido del archivo**
   - El programa descomprimirá el contenido del archivo seleccionado (formato `.zip` internamente).

3. **Mostrar contenido extraído**
   - Se listarán los archivos `.webp` (stickers) contenidos en el `.wastickers`.

4. **Guardar imágenes en carpeta local**
   - El usuario seleccionará una carpeta de destino (`FolderBrowserDialog`) donde se copiarán las imágenes extraídas.

5. **Ver notificación de éxito**
   - Al finalizar, el programa notificará al usuario que la extracción fue exitosa (mediante `MessageBox`).

## 🛠️ Requisitos Técnicos

1. **Lenguaje y Plataforma**
   - Lenguaje: C#
   - Plataforma: .NET 6 o superior
   - Interfaz: Windows Forms (WinForms)

2. **Librerías del Sistema**
   - `System.IO.Compression.ZipArchive` para la extracción.
   - `System.Drawing` si luego quieres mostrar previews de las imágenes.
   - `OpenFileDialog` y `FolderBrowserDialog` para selección de archivos y carpetas.

3. **Compatibilidad**
   - Ejecutable `.exe` para Windows (x64).
   - Opción para compilar como *self-contained* (sin requerir instalación de .NET).

4. **Nombre del archivo**
   - Nombre sugerido para el ejecutable: `WaStickersExtractorGUI.exe`.
