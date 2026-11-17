# Laboratorio: Validaciones, Métodos Estáticos y Nuevos Controles

**Universidad Tecnológica de Panamá**
Facultad de Ingeniería en Sistemas y Computacionales
Licenciatura en Ingeniería en Sistemas y Computación
Herramientas de la Programación Aplicada III (.Net) — Prof. Irina Fong

**Estudiante:** Gaitán, Josseline — 8-1018-226
**Grupo:** 1IL133
**Fecha:** 17 de noviembre de 2026

---

## Descripción

Este repositorio contiene el desarrollo del laboratorio correspondiente al módulo de
**validaciones, métodos estáticos y nuevos controles de Windows Forms** en C#. El
trabajo se organiza en tres proyectos independientes, cada uno enfocado en un
conjunto de conceptos distintos del lenguaje y del framework .NET:

| Proyecto | Concepto principal | Tipo de app |
|---|---|---|
|<img width="747" height="647" alt="image" src="https://github.com/user-attachments/assets/86616e82-8af4-46e1-a16a-0a0bd7ecf1b8" /> | Validaciones de datos, clase `static`, `ErrorProvider`, `DataGridView` | Windows Forms |
|<img width="1122" height="623" alt="image" src="https://github.com/user-attachments/assets/40530981-752e-41be-a58b-0fb0538ba7a7" />| Enumeraciones, estructuras de control, generación de números aleatorios | Consola |
| <img width="912" height="632" alt="image" src="https://github.com/user-attachments/assets/996949ed-b4d1-4d4f-80fe-cf443150ca6e" />| Formularios MDI (padre/hijo), `MenuStrip` | Windows Forms |

---

## Tecnologías utilizadas

| Tecnología | Versión / Detalle |
|---|---|
| Lenguaje | C# |
| Framework (`DataGridView A1`, `Juegos de Craps`) | .NET Framework 4.7.2 |
| Framework (`MDI`) | .NET 10.0 (`net10.0-windows`) |
| IDE | Visual Studio 2026 |
| Tipo de proyecto | Windows Forms App y Aplicación de consola |
| Control de versiones | Git / GitHub |

### Controles utilizados

| Proyecto | Controles |
|---|---|
| `DataGridView A1` | `DataGridView`, `ErrorProvider`, `DateTimePicker`, `ToolStrip` / `ToolStripButton`, `TextBox`, `Label` |
| `Juegos de Craps` | Consola (`Console`), clase `Random`, `enum` |
| `MDI` | `MenuStrip`, formulario padre (`IsMdiContainer`) y formulario hijo (`MdiParent`) |

---

## Instalación y ejecución

1. Clonar o descargar el repositorio:
   ```
   git clone https://github.com/<usuario>/Laboratorio-Validaciones--Metodos-Estaticos-y-Nuevos-Controles.git
   ```
2. Instalar **Visual Studio** con la carga de trabajo *Desarrollo de escritorio con .NET*
   (para `MDI` se requiere el SDK de **.NET 10**; para los otros dos, .NET Framework 4.7.2).
3. Abrir la solución del proyecto deseado (`.sln` / `.slnx`).
4. Compilar y ejecutar con **F5**.

---

## Estructura del repositorio

```
├── DataGridView A1/          # Formulario con validaciones y DataGridView
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Persona.cs
│   ├── Utilidades.cs
│   └── Program.cs
├── imagenes/                  # Capturas usadas en este README
├── Juegos de Craps/           # Aplicación de consola: juego de dados Craps
│   ├── Craps.cs
│   └── Program.cs
└── MDI/                       # Aplicación con formularios MDI (padre/hijo)
    ├── Form1.cs / Form1.Designer.cs
    └── Form2.cs / Form2.Designer.cs
```

---

## 1. DataGridView A1 — Validaciones y nuevos controles

Formulario de registro de empleados que combina varios controles nuevos con
validación de datos antes de guardar cada registro.

**Clases principales:**

- **`Persona`** — clase de modelo con las propiedades `Id`, `Nombres`, `Apellidos`,
  `Correo`, `FechaNacimiento` y `Salario`, usada como fuente de datos del
  `DataGridView`.
- **`Utilidades`** — clase **estática** con métodos de validación reutilizables:
  - `EstaEnBlanco(string texto)` — determina si un campo de texto está vacío.
  - `EsCorreoValido(string email)` — valida el formato de un correo electrónico
    mediante una expresión regular.
- **`Form1`** — contiene la lógica de la interfaz:
  - Al cargar el formulario, se agrega una `Persona` de ejemplo a un `ArrayList`
    y se enlaza como `DataSource` del `DataGridView` (`dgvDatos`).
  - El botón **Guardar** (`toolStripButton1`) valida cada campo con la clase
    `Utilidades` y muestra los errores mediante un `ErrorProvider`; si todos los
    campos son válidos, crea una nueva `Persona`, la agrega a la lista y
    refresca el `DataGridView`.
  - El botón **Limpiar** (`toolStripButton2`) reinicia todos los campos del
    formulario y limpia los errores mostrados.

**Controles nuevos utilizados:** `DataGridView`, `ErrorProvider`, `DateTimePicker`,
`ToolStrip` / `ToolStripButton`.

**Cómo ejecutar:**
1. Abrir `DataGridView A1.sln` en Visual Studio.
2. Compilar y ejecutar (F5).
3. Completar los campos y presionar **Guardar** para ver la validación en acción.

**Resultados:**

| Validaciones (campos vacíos / correo inválido) | Registro guardado en el `DataGridView` |
|---|---|
| <img width="747" height="647" alt="image" src="https://github.com/user-attachments/assets/2b3c751a-10bc-4d6c-8803-73df935fa2c5" /> | <img width="860" height="642" alt="image" src="https://github.com/user-attachments/assets/b174b125-5ceb-4f1f-9742-3de337bf991d" /> |

---

## 2. Juegos de Craps — Lógica con enumeraciones

Aplicación de consola que simula el juego de dados **Craps**.

**Clase `Craps`:**

- Usa dos enumeraciones privadas:
  - `Estado { CONTINUA, GANO, PERDIO }` — controla el flujo del juego.
  - `NombreDados { DOS_UNO = 2, TRES = 3, SIETE = 7, ONCE = 11, DOCE = 12 }` —
    identifica los resultados relevantes del primer lanzamiento.
- **`TirarDados()`** — genera dos números aleatorios entre 1 y 6 con la clase
  `Random`, calcula su suma, la imprime en consola y la retorna.
- **`Jugar()`** — implementa las reglas del Craps:
  - Gana en el primer tiro si la suma es 7 u 11.
  - Pierde en el primer tiro si la suma es 2, 3 o 12.
  - En cualquier otro caso, ese valor se convierte en el "punto"; el juego
    continúa tirando los dados hasta que se repita el punto (gana) o salga un
    7 (pierde).

**Cómo ejecutar:**
1. Abrir `Juegos de Craps.sln` en Visual Studio.
2. Compilar y ejecutar (F5) o desde consola con `dotnet run`.
3. El resultado de cada tirada y el resultado final se muestran por consola.

**Resultados:**

| Partida ganada | Partida perdida |
|---|---|
| <img width="1481" height="748" alt="image" src="https://github.com/user-attachments/assets/bb078ad9-abcd-409c-a7ac-9093046fb08c" />| <img width="1481" height="756" alt="image" src="https://github.com/user-attachments/assets/76bbff38-4757-475c-b64f-1d45cf4edadd" />
 |

---

## 3. MDI — Formularios de interfaz de múltiples documentos

Aplicación Windows Forms que demuestra el patrón **MDI (Multiple Document
Interface)**: un formulario padre que puede contener múltiples formularios hijo.

- **`Form1`** — formulario padre (`IsMdiContainer = true`) con un `MenuStrip`
  que incluye la opción **Ventanas → Abrir FormHijo1**. Al hacer clic, si ya
  existe una instancia abierta de `Form2` la trae al frente (`BringToFront`);
  si no, crea una nueva instancia, le asigna `MdiParent = this` y la muestra.
- **`Form2`** — formulario hijo que se despliega dentro del área del formulario
  padre.

**Cómo ejecutar:**
1. Abrir la solución `MDI` en Visual Studio.
2. Compilar y ejecutar (F5).
3. Desde el menú **Ventanas**, seleccionar **Abrir FormHijo1** para ver el
   formulario hijo dentro del contenedor MDI.

**Resultados:**

| Formulario padre con el menú | Formulario hijo dentro del contenedor |
|---|---|
| <img width="911" height="635" alt="image" src="https://github.com/user-attachments/assets/3240fcf2-d537-4571-9918-521abd059fa4" /> | <img width="911" height="632" alt="image" src="https://github.com/user-attachments/assets/26db08a6-ccb6-4ca3-b4f6-651d1ce27825" /> |

---

## Autora

**Josseline Gaitán** — 8-1018-226 — Grupo 1IL133

## Referencias

- Guía del Laboratorio — Ing. Irina Fong
- Documentación oficial de C# (Microsoft Learn)
