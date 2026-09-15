# Laboratorio: Validaciones, Métodos Estáticos y Nuevos Controles

**Universidad Tecnológica de Panamá**
Facultad de Ingeniería en Sistemas y Computacionales
Licenciatura en Ingeniería en Sistemas y Computación
Herramientas de la Programación Aplicada III (.Net) — Prof. Irina Fong

**Estudiante:** Gaitán, Josseline — 8-1018-226
**Grupo:** 1IL133

---

## Descripción

Este repositorio contiene el desarrollo del laboratorio correspondiente al módulo de
**validaciones, métodos estáticos y nuevos controles de Windows Forms** en C#. El
trabajo se organiza en tres proyectos independientes, cada uno enfocado en un
conjunto de conceptos distintos del lenguaje y del framework .NET:

| Proyecto | Concepto principal | Tipo de app |
|---|---|---|
| [`DataGridView A1`](#1-datagridview-a1--validaciones-y-nuevos-controles) | Validaciones de datos, clase `static`, `ErrorProvider`, `DataGridView` | Windows Forms |
| [`Juegos de Craps`](#2-juegos-de-craps--lógica-con-enumeraciones) | Enumeraciones, estructuras de control, generación de números aleatorios | Consola |
| [`MDI`](#3-mdi--formularios-de-interfaz-de-múltiples-documentos) | Formularios MDI (padre/hijo), `MenuStrip` | Windows Forms |

---

## Tecnologías utilizadas

- **Lenguaje / Framework:** C# — .NET Framework 4.7.2 (`DataGridView A1`, `Juegos de Craps`) y .NET 10.0 (`MDI`)
- **IDE:** Visual Studio 2026
- **Tipo de proyecto:** Windows Forms App y Aplicación de consola
- **Control de versiones:** Git / GitHub

---

## Estructura del repositorio

```
├── DataGridView A1/          # Formulario con validaciones y DataGridView
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Persona.cs
│   ├── Utilidades.cs
│   └── Program.cs
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

---

## Autora

**Josseline Gaitán** — 8-1018-226 — Grupo 1IL133

## Referencias

- Guía del Laboratorio — Ing. Irina Fong
- Documentación oficial de C# (Microsoft Learn)
