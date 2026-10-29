# Dziennik weryfikacji

Wpisy od najnowszego. Zapisuję wynik sprawdzenia, nie wrażenie.

## 2026-10-29 — przegląd zewnętrzny: nawigacja przez `MainWindow.Instance`

- Przeglądający: Oskar, wymiana repozytoriów w zadaniu 3.7.
- Fragment, którego nie rozumiem: `katalog/ListScreen.axaml.cs`, linie 96–99 — `MainWindow.Instance?.SetScreen(new DetailsScreen(item));`; w `katalog/MainWindow.axaml.cs` linie 7 i 12 — `public static MainWindow? Instance { get; private set; }` i `Instance = this;`.
- Pytanie do autora: dlaczego ekrany sięgają po okno przez statyczne `Instance`, zamiast dostać je w konstruktorze, i po co `?.` — czy `Instance` naprawdę może być `null`?
- Odpowiedź autora: „`Instance` ustawiam w konstruktorze okna, żeby ekrany nie musiały dostawać referencji do okna — bez tego każde `new ListScreen(...)` musiałoby przekazywać `this`, a ekrany tworzą się też z kodu okna. `?.` jest na wypadek, gdyby ekran próbował nawigować, zanim okno powstało, np. w podglądzie w designerze; przy normalnym uruchomieniu `Instance` nigdy nie jest `null`.”
- Czy odpowiedź była natychmiastowa, czy trzeba było jej szukać w kodzie: pierwsza część od razu, z pamięci; przy `?.` autor musiał zajrzeć do `MainWindow.axaml.cs` i sprawdzić, gdzie `Instance` jest przypisywane, zanim odpowiedział, że w działającej aplikacji nie może być `null`.
