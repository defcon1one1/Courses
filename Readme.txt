1. W celu zalogowania można użyć formularza rejestracji
2. Widok Courses jest dostępna dla niezalogowanych użytkowników, widok Admin dla zarejestrowanych
3. W widoku Admin dostępne są dwa główne formularze:
	Add Course - dodaje kurs walidując input użytkownika, property ReleaseDate jest przypisywane automatycznie
	Add Lesson - dodaje lekcję do kursu
4. Poniżej widoczna jest lista kursów z odnośnikami do następujących formularzy:
	Edit - możliwość edycji nazwy, ceny, poziomu zaawansowania, instruktora
	Delete - możliwość usunięcia kursu (kaskadowo wraz z lekcjami)
	View Details - pokazuje szczegóły kursu, wraz z listą lekcji, ten widok zawiera również listę lekcji z kolejnymi formularzami:
		Edit - edycja nazwy lekcji i kursu do którego należy
		Delete - możliwość usunięcia lekcji
5. Listę instruktorów należy zahardkodować w bazie SQL.
