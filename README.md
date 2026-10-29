# Katalog Zbioru — Zadanie 3.3

Aplikacja desktopowa w technologii **C# / .NET / Avalonia**, służąca do zarządzania katalogiem pozycji (tytuł, rok, ocena) w modelu jedno-okienkowym z trzema wymiennymi ekranami. Projekt zrealizowany w ramach Zadania 3.3 kursu programowania z agentami AI.

---

## 1. Cel projektu

Celem projektu jest utworzenie aplikacji desktopowej w architekturze pojedynczego okna (Single Window Navigation), która:
- Odczytuje i zapisuje pozycje katalogu w pliku tekstowym `dane/pozycje.txt` w formacie CSV (`tytuł;rok;ocena`),
- Posiada trzy ekrany: listę pozycji, ekran szczegółów oraz formularz dodawania nowej pozycji,
- Korzysta z trwałego pliku reguł `AGENTS.md` do standaryzacji pracy agentów AI,
- Dokumentuje wyniki eksperymentu z regułami w świeżych sesjach asystenta AI.

---

## 2. Technologie i wymagania środowiskowe

- **Język:** C# (.NET 10.0 / .NET 9.0+)
- **Framework UI:** Avalonia UI (v12.1.3, Fluent Theme, Inter Font)
- **Architektura:** Brak automatycznego wiązania danych (bez MVVM/XAML Data Binding), brak zewnętrznych bibliotek spoza bazowego szablonu Avalonia.
- **System operacyjny:** Windows / Linux / macOS (multiplatformowość zapewniona przez Avalonia UI).

---

## 3. Instrukcja uruchomienia

1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/maksymiliangorka1/3.3-katalogna3ekranachiplikregul-4ta-2-Maksymilian-G.git
   cd 3.3-katalogna3ekranachiplikregul-4ta-2-Maksymilian-G
   ```
2. Przejdź do katalogu projektu i skompiluj aplikację:
   ```bash
   cd katalog
   dotnet build
   ```
3. Uruchom aplikację:
   ```bash
   dotnet run
   ```

---

## 4. Opis trzech ekranów aplikacji

1. **Ekran listy pozycji (`ListScreen.axaml` / `ListScreen.axaml.cs`):**
   - Wczytuje i prezentuje pozycje z pliku `dane/pozycje.txt` (tytuł, rok, ocena).
   - Umożliwia zaznaczenie elementu i przejście do jego szczegółów przyciskiem „Szczegóły”.
   - Posiada przycisk „Dodaj nową pozycję” otwierający formularz dodawania.
   - Zawiera przycisk „Policz” zliczający na żywo liczbę pozycji w pliku.
2. **Ekran szczegółów (`DetailsScreen.axaml` / `DetailsScreen.axaml.cs`):**
   - Wyświetla pełne dane wybranej pozycji: tytuł, rok premiery i ocenę w skali 1-10.
   - Posiada przycisk „Powrót do listy”, który przywraca widok listy w tym samym oknie.
3. **Ekran formularza dodawania (`AddScreen.axaml` / `AddScreen.axaml.cs`):**
   - Zawiera pola tekstowe dla tytułu, roku i oceny.
   - Wykonuje walidację wprowadzonych danych (brak pustych pól, brak średników w tytule, zakres roku 1800-2100, ocena 1-10).
   - Zapisuje nową pozycję na końcu pliku `dane/pozycje.txt` z kodowaniem UTF-8, zachowując istniejące pozycje.
   - Przycisk „Powrót do listy” pozwala wrócić bez zapisywania.

---

## 5. Format pliku danych `dane/pozycje.txt`

Plik tekstowy zapisany w kodowaniu **UTF-8** z separatorami średnikowymi:
```text
tytuł;rok;ocena
```

Startowa zawartość pliku:
```text
Diuna;2021;8
Ronja, córka zbójnika;1981;10
Osada;2023;6
```
Obsługiwane są polskie znaki diakrytyczne oraz przecinki w tytułach (np. *„Ronja, córka zbójnika”*).

---

## 6. Plik `AGENTS.md` i eksperyment z regułami

Zasady projektu zostały zdefiniowane w pliku `AGENTS.md` w głównym katalogu repozytorium.

### Początkowy zestaw reguł:
1. Interfejs po polsku, nazwy plików, klas i metod po angielsku.
2. Jeden ekran to jeden plik `.axaml` i jeden plik `.axaml.cs`.
3. Nie dodawaj do projektu bibliotek, których nie było w szablonie.
4. Dane wczytujemy z pliku `dane/pozycje.txt`, format `tytuł;rok;ocena`.
5. Wszystkie pliki tekstowe projektu zapisuj w UTF-8.
6. Nie zmieniaj plików, o które nie było prośby.
7. Krótkie metody: jedna metoda odpowiada za jedno zadanie.

### Wynik pierwszego sprawdzenia (ekran szczegółów):
- **Liczba złamanych reguł przy pierwszym sprawdzeniu:** **1**
- **Złamana reguła:** Reguła 6 (*„Nie zmieniaj plików, o które nie było prośby”*).
  - *Przyczyna:* Agent musiał zaktualizować `ListScreen.axaml.cs`, aby umożliwić nawigację z listy do nowo utworzonego ekranu szczegółów. Reguła była zbyt restrykcyjna i uniemożliwiała wymaganą integrację nowego komponentu z aplikacją.
- **Reguła niejednoznaczna / zbyt ogólna:** Reguła 7 (*„Krótkie metody: jedna metoda odpowiada za jedno zadanie”*) – określenie „krótkie” było subiektywne i niemierzalne.

### Wprowadzone poprawki w `AGENTS.md`:
1. **Reguła 6:** Zmieniono na: *„Nie zmieniaj plików spoza zakresu zadania; modyfikacje istniejących plików ograniczaj wyłącznie do podpięcia nawigacji.”*
2. **Reguła 7:** Doprecyzowano do formy mierzalnej: *„Jedna metoda odpowiada za jedno zadanie i nie przekracza 25 linii kodu.”*
3. **Reguła 4:** Rozszerzono o dopisywanie danych: *„Dane wczytujemy i dopisujemy do pliku `dane/pozycje.txt`, format `tytuł;rok;ocena` bez usuwania istniejących wpisów.”*

### Wynik ostatniego sprawdzenia (formularz dodawania):
- **Liczba złamanych reguł przy ostatnim sprawdzeniu:** **0**
- Wszystkie 7 dopracowanych reguł zostało w 100% dotrzymanych przez agenta.

---

## 7. Przycisk „Policz” i wynik testu

Przycisk „Policz” został dodany do ekranu listy `ListScreen`:
- W `ListScreen.axaml`: kontrolka `<Button Click="OnCountClick">Policz</Button>` oraz etykieta `<TextBlock Name="CountText" />`.
- W `ListScreen.axaml.cs`: metoda `OnCountClick` wykonująca `File.ReadAllLines` na aktualnym pliku danych przy każdym kliknięciu.

### Wyniki testów działania:
1. Przy uruchomieniu i pierwszym kliknięciu „Policz”: wyświetlono `Pozycji w pliku: 3`.
2. Po dopisaniu testowej pozycji `Seksmisja;1984;9` i ponownym kliknięciu „Policz”: wyświetlono `Pozycji w pliku: 4`.
3. Przycisk poprawnie odczytuje fizyczny plik przy każdym wywołaniu, a nie bazuje na zapamiętanej wartości początkowej.

---

## 8. Informacje o narzędziu AI i obsłudze reguł

- **Używane środowisko:** Google Antigravity IDE (silnik Gemini 3.8 Flash High / Antigravity 2.0).
- **Czy narzędzie automatycznie odczytuje `AGENTS.md`:** **Tak**. Narzędzie posiada wbudowany mechanizm odkrywania reguł w plikach `AGENTS.md` oraz `GEMINI.md`.
- **Gdzie powinien znajdować się plik reguł:** Plik reguł może znajdować się w głównym katalogu projektu/repozytorium (`AGENTS.md` lub `GEMINI.md`), w podkatalogu `.agents/rules/*.md` lub w konfiguracji globalnej użytkownika `~/.gemini/config/`. Narzędzie przeszukuje hierarchię katalogów od otwieranego pliku w górę do korzenia repozytorium.
- **Link do dokumentacji producenta:**
  - Oficjalny portal Antigravity: [https://antigravity.google](https://antigravity.google)
  - Ot استاندارد reguł agentów: [https://agents.md](https://agents.md)
- **Faktyczna data odczytania dokumentacji:** **29.10.2026**.
- **Porównanie z innym narzędziem:**
  - W edytorze **Cursor** reguły projektu są tradycyjnie zapisywane w pliku `.cursorrules` lub `.cursor/rules/*.mdc`.
  - W narzędziu **Claude Code** wykorzystywany jest plik `CLAUDE.md`.
  - **Antigravity** wspiera zarówno otwarty, wielonarzędziowy standard `AGENTS.md`, jak i dedykowany `GEMINI.md`, zapewniając pełną kompatybilność hierarchiczną.
