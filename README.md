# Programes d'Exemple en C#

Aquest repositori conté dos programes educatius en C# que demostren conceptes fonamentals de programació.

## 📋 Contingut

1. [Champion Utility Program](#champion-utility-program)
2. [Sistema Bancari ING](#sistema-bancari-ing)
3. [Conceptes Teòrics](#conceptes-teòrics)

---

## 🎮 Champion Utility Program

### Descripció
Programa d'utilitats per gestionar informació de campions (basat en League of Legends). Demostra l'ús de diferents tipus de funcions en C#.

### Funcionalitats

- **Calcular atac del campió**: Suma l'atac base més un bonus
- **Obtenir rol del campió**: Identifica el rol segons el nom del campió
- **Probabilitat de cop crític**: Genera aleatòriament una probabilitat de crític (25%)
- **Mode administrador**: Opció oculta per habilitar funcions especials

### Campions Inclosos

| Campió | Rol |
|---------|-----|
| Ashe, Caitlyn, Jinx | Marksman |
| Garen, Darius, Mordekaiser | Fighter |
| Lux, Annie, Veigar | Mage |

### Conceptes Demostrats

#### Tipus de Funcions

**1. Funcions que reben paràmetres però no retornen res**
```csharp
public static void ShowMessage(string message)
{
    Console.WriteLine(message);
}
```
- Reben dades d'entrada
- Executen una acció (mostrar missatge)
- No retornen cap valor

**2. Funcions que no reben paràmetres ni retornen res**
```csharp
public static void AdminModeEnabled()
{
    Console.WriteLine(MessageAdmin);
}
```
- Són autònomes
- Executen una tasca específica
- No necessiten dades externes

**3. Funcions que retornen però no reben paràmetres**
```csharp
public static bool GetRandomCriticalChance()
{
    Random rand = new Random();
    int chance = rand.Next(1, 101);
    return chance <= 25;
}
```
- Generen un valor internament
- Retornen un resultat
- Útils per generar dades aleatòries o accedir a valors globals

**4. Funcions que reben paràmetres i retornen valors**
```csharp
public static int CalcAttackChampion(int attack, int bonus)
{
    int totalAttack = attack + bonus;
    return totalAttack;
}
```
- Processen dades d'entrada
- Retornen un resultat calculat
- El tipus més comú i versàtil

---

## 🏦 Sistema Bancari ING

### Descripció
Sistema bancari simplificat que demostra el pas de paràmetres per **valor**, **referència** (`ref`), **entrada** (`in`) i **sortida** (`out`) en C#.

### Funcionalitats

- **Verificar targeta de crèdit**: Mostra el número de targeta i saldo
- **Retirar efectiu**: Resta una quantitat del saldo i mostra el resultat
- **Calcular interessos**: Calcula el 15% d'interès sobre el saldo actual

### Exemples de Variables
```csharp
// VARIABLE GLOBAL (constant)
const double TaxRate = 0.15;

// VARIABLE GLOBAL (estàtica)
static double amount = 1000.0;

public static void Main()
{
    // VARIABLES LOCALS
    int op = 0;
    int creditCardNumber = 123456789;
    double previousAmount = amount, finalAmount;
    
    // Aquestes variables només existeixen dins de Main
}
```

---

## 📚 Conceptes Teòrics

### 1️⃣ Variables Locals vs Globals

#### Variables Locals
```csharp
public static void Main()
{
    int op = 0;  // Variable LOCAL
    // Només accessible dins de Main
}
```

**Característiques:**
- ✅ Declarades dins d'una funció o bloc de codi
- ✅ Només accessibles dins d'aquest àmbit (scope)
- ✅ Es creen quan s'entra a la funció
- ✅ Es destrueixen quan se surt de la funció
- ✅ **Ús recomanat**: Mantenen el codi net i eviten conflictes

**Exemple:**
```csharp
public static void Function1()
{
    int number = 10;  // Local a Function1
    Console.WriteLine(number);
}

public static void Function2()
{
    // Console.WriteLine(number);  // ERROR! 'number' no existeix aquí
}
```

#### Variables Globals
```csharp
public class Program
{
    const double TaxRate = 0.15;      // GLOBAL (constant)
    static double amount = 1000.0;     // GLOBAL (estàtica)
    
    public static void Main()
    {
        Console.WriteLine(TaxRate);    // ✅ Accessible
        Console.WriteLine(amount);     // ✅ Accessible
    }
    
    public static void OtherFunction()
    {
        Console.WriteLine(TaxRate);    // ✅ Accessible
        Console.WriteLine(amount);     // ✅ Accessible
    }
}
```

**Característiques:**
- ✅ Declarades a nivell de classe
- ✅ Accessibles des de qualsevol funció de la classe
- ✅ Mantenen el seu valor durant tota l'execució del programa
- ⚠️ Han de ser `static` si les funcions són `static`
- ⚠️ **Usar amb moderació**: Poden fer el codi difícil de mantenir

**Quan usar-les:**
- Constants que s'utilitzen en molts llocs (`TaxRate`)
- Dades compartides entre funcions (`amount`)
- Configuracions globals

---

### 2️⃣ Pas de Paràmetres per Valor

**PER DEFECTE** en C#, els paràmetres es passen **per valor**.
```csharp
public static void ModifyNumber(int number)
{
    number = 100;  // Només modifica la còpia local
}

public static void Main()
{
    int myNumber = 10;
    ModifyNumber(myNumber);
    Console.WriteLine(myNumber);  // Imprimeix: 10 (NO ha canviat!)
}
```

**Què passa:**
1. Es crea una **còpia** del valor de `myNumber`
2. La funció treballa amb aquesta còpia
3. Els canvis dins la funció NO afecten la variable original
4. Quan acaba la funció, la còpia es destrueix

**Diagrama:**
```
Main:           myNumber = 10
                    ↓ (còpia)
ModifyNumber:   number = 10 → number = 100
                    ↓
Main:           myNumber = 10 (sense canvis)
```

---

### 3️⃣ Pas de Paràmetres per Referència (`ref`)

Amb `ref`, passem **l'adreça de memòria** de la variable, no una còpia.
```csharp
public static int Menu(ref int op)
{
    do
    {
        Console.WriteLine("Tria una opció:");
    } while (!int.TryParse(Console.ReadLine(), out op));
    
    return op;  // op s'ha modificat i el canvi es reflecteix fora
}

public static void Main()
{
    int option = 0;
    Menu(ref option);  // ⚠️ Cal usar 'ref' també a la crida
    // Ara 'option' té el valor introduït per l'usuari
}
```

**Característiques:**
- ✅ La variable **ha d'estar inicialitzada** abans de passar-la
- ✅ Els canvis dins la funció **afecten la variable original**
- ✅ Cal usar `ref` tant a la declaració com a la crida
- ✅ És com passar un "punter" a la variable

**Diagrama:**
```
Main:           option = 0
                    ↓ (referència/adreça)
Menu:           op → apunta a option → op = 5
                    ↓
Main:           option = 5 (HA canviat!)
```

**Exemple pràctic:**
```csharp
public static void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

public static void Main()
{
    int x = 10, y = 20;
    Console.WriteLine($"Abans: x={x}, y={y}");  // x=10, y=20
    
    Swap(ref x, ref y);
    
    Console.WriteLine($"Després: x={x}, y={y}"); // x=20, y=10
}
```

---

### 4️⃣ Paràmetres d'Entrada (`in`)

El modificador `in` indica que el paràmetre és **només de lectura**.
```csharp
public static double CalculateInterest(in double amount)
{
    // amount = 10;  // ❌ ERROR! No es pot modificar
    return amount * TaxRate;  // ✅ Només lectura
}

public static void Main()
{
    double balance = 1000.0;
    double interest = CalculateInterest(in balance);
    // balance segueix sent 1000.0
}
```

**Característiques:**
- ✅ El paràmetre **no es pot modificar** dins la funció
- ✅ Es passa per referència (eficient per a tipus grans)
- ✅ Garanteix que la funció no canviarà el valor
- ✅ Millora el rendiment amb estructures grans
- ✅ Documenta la intenció del programador

**Quan usar-lo:**
- Funcions que necessiten llegir un valor però no modificar-lo
- Per millorar el rendiment amb estructures grans
- Per garantir que les dades d'entrada no canviïn

**Comparació:**
```csharp
// Passa una còpia (menys eficient per tipus grans)
public static void Method1(double value) { }

// Passa per referència, però només lectura (més eficient i segur)
public static void Method2(in double value) { }
```

---

### 5️⃣ Paràmetres de Sortida (`out`)

El modificador `out` s'usa per **retornar múltiples valors**.
```csharp
public static void WithdrawCash(int cash, in double previousAmount, out double finalAmount)
{
    finalAmount = previousAmount - cash;
    // ⚠️ OBLIGATORI assignar un valor a 'finalAmount' abans d'acabar
}

public static void Main()
{
    double balance = 1000.0;
    double newBalance;  // No cal inicialitzar-la!
    
    WithdrawCash(100, in balance, out newBalance);
    
    Console.WriteLine($"Saldo anterior: {balance}");      // 1000.0
    Console.WriteLine($"Saldo nou: {newBalance}");        // 900.0
}
```

**Característiques:**
- ✅ **NO cal inicialitzar** la variable abans de passar-la
- ✅ La funció **OBLIGA** a assignar un valor abans d'acabar
- ✅ Útil per retornar múltiples valors
- ✅ Més clar que usar `ref` per a valors de sortida
- ✅ Cal usar `out` tant a la declaració com a la crida

**Exemple amb múltiples sortides:**
```csharp
public static void GetMinMax(int[] numbers, out int min, out int max)
{
    min = numbers[0];
    max = numbers[0];
    
    foreach (int num in numbers)
    {
        if (num < min) min = num;
        if (num > max) max = num;
    }
    // Obligatori assignar valors a 'min' i 'max'
}

public static void Main()
{
    int[] array = { 5, 2, 9, 1, 7 };
    int minimum, maximum;  // No cal inicialitzar
    
    GetMinMax(array, out minimum, out maximum);
    
    Console.WriteLine($"Min: {minimum}, Max: {maximum}");  // Min: 1, Max: 9
}
```

**Alternativa moderna (C# 7.0+):**
```csharp
// Declaració inline
GetMinMax(array, out int minimum, out int maximum);
```

---

## 📊 Taula Comparativa

| Modificador | Inicialització | Es pot modificar? | Canvis visibles fora? | Ús típic |
|-------------|----------------|-------------------|----------------------|----------|
| **Per valor** (defecte) | ✅ Sí | ✅ Sí (còpia) | ❌ No | Entrada de dades |
| **`ref`** | ✅ Sí (obligatori) | ✅ Sí (original) | ✅ Sí | Entrada/Sortida |
| **`in`** | ✅ Sí | ❌ No (només lectura) | ❌ No | Entrada protegida |
| **`out`** | ❌ No necessari | ✅ Sí (obligatori) | ✅ Sí | Sortida de dades |

---

## 🔍 Exemples Pràctics Comparatius

### Exemple 1: Calculadora
```csharp
// Per valor: retorna el resultat
public static int Add(int a, int b)
{
    return a + b;
}

// Amb 'out': retorna múltiples resultats
public static void Calculate(int a, int b, out int sum, out int product)
{
    sum = a + b;
    product = a * b;
}

// Amb 'in': protegeix els paràmetres d'entrada
public static double CalculateTax(in double amount, in double rate)
{
    // amount = 0;  // ❌ Error de compilació
    return amount * rate;
}
```

### Exemple 2: Comptador
```csharp
// Amb 'ref': modifica una variable existent
public static void Increment(ref int counter)
{
    counter++;
}

public static void Main()
{
    int count = 0;
    Increment(ref count);  // count = 1
    Increment(ref count);  // count = 2
    Increment(ref count);  // count = 3
}
```

---

## 🚀 Com Executar

### Requisits
- .NET SDK instal·lat
- Editor de codi (Visual Studio, VS Code, Rider)

### Compilació i Execució
```bash
# Champion Utility Program
csc BasicFunctions.cs
BasicFunctions.exe

# Sistema Bancari ING
csc Program.cs
Program.exe
```

O des de Visual Studio/VS Code, simplement executar el projecte.

---

## 💡 Bones Pràctiques

### Variables
- ✅ **Prefereix variables locals** sempre que sigui possible
- ✅ Usa variables globals només per constants o dades compartides
- ✅ Dona noms descriptius a les variables

### Pas de Paràmetres
- ✅ Usa **per valor** per defecte (més segur)
- ✅ Usa **`in`** per estructures grans que només llegeixes
- ✅ Usa **`out`** per retornar múltiples valors
- ✅ Usa **`ref`** quan necessitis entrada/sortida simultània
- ⚠️ Evita `ref` si pots usar un valor de retorn normal

### Funcions
- ✅ Una funció ha de fer **una sola cosa** i fer-la bé
- ✅ Usa noms descriptius (`CalculateInterest` millor que `Calc`)
- ✅ Manté les funcions curtes i llegibles

---

## ⚠️ Notes

- El codi conté alguns errors intencionals per a propòsits didàctics
- Els valors estan codificats directament per simplificar els exemples
- No inclou gestió avançada d'excepcions

---

## 📝 Llicència

Codi educatiu d'exemple - Lliure ús per a aprenentatge
