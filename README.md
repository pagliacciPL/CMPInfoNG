# CMPInfoNG

Prosta aplikacja (tool) napisana w C# wyświetlająca informacje na temat komputera/ konta użytkownika. Aplikacja inspirowana BGInfo. 


Uwagi:

1. W klasie Methods definiujemy metody, które odpowiadają za pobierania danych zaś w pliku konfiguracyjnym definujemy nazwę klucza i wartość (np. USER - GetUser). 

2. Active Directory nie przechowuje daty wygaśnięcia hasła a datę ostatniej zmiany hasła i na tej podstawie określa 
datę wygaśnięcia hasła dodając do daty ostatniej zmiany hasła liczbę dni zdefiniowanych w AD po których to dniach należy zmienić hasło. Dlatego w metodzie GetExpiration jest użyty kod dodający 42 dni do daty ostatniej zmiany hasła.

3. Ikona komputera wykorzystana z aplikacji pochodzi z https://www.iconfinder.com/icons/51413/.

4. Aplikacja rozpowszechniana na licencji freeware/opensource.

5. Wszelkie uwagi/komentarze proszę kierować na pagliacciPL at protonmail.com . Będę również wdzięczny za informację o tym, że ktoś używa tej aplikacji.
