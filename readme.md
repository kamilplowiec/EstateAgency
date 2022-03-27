Biuro nieruchomoœci (EstateAgency)

1. Dodawanie, edycja, wyszukiwanie nieruchomoœci
2. Dodawanie, edycja, wyszukiwanie klientów
3. Mozliwoœæ kupna lub wynajêcia mieszkania przez klienta (je¿eli wynajem, to na jaki okres)
4. Mo¿liwoœæ do³¹czenia miejsca parkingowego do mieszkania

________Opis dzia³ania____________

1. Logowanie do aplikacji odbywa sie przez wybór dzia³ania trybu programu (Deweloper lub Klient). Klikniêcie Zamknij zakoñczy dzia³anie programu.

1.1. Deweloper - osoba maj¹ca mo¿liwoœæ dodawania og³oszeñ mieszkañ, akceptacji zakupu/wynajmu mieszkania.
1.2. Klient - anonimowa osoba, mog¹ca przegl¹daæ og³oszenia mieszkañ i z³o¿yæ ofertê kupna/wynajmu.

2. Panel wyszukiwarki mieszkañ

2.1. Deweloper - ma mo¿liwoœæ wyszukiwania mieszkañ wed³ug nazwy i adresu (wpisuj¹c w jednym polu). Widzi skrócone dane o mieszkaniu (nazwa, typ, piêtro, cena, adres, czy ma parking) oraz czy mieszkanie jest ju¿ wynajête/kupione. Klikniêcie w rekord umo¿liwia edycjê danych og³oszenia.

2.2. Klient - ma mo¿liwoœæ wyszukiwania mieszkañ wed³ug nazwy i adresu (wpisuj¹c w jednym polu). Widzi skrócone dane o mieszkaniu (nazwa, typ, piêtro, cena, adres, czy ma parking). Klikniêcie w rekor umo¿liwia wyœwietlenie pe³nych informacji o mieszkaniu.

3. Kup/wynajmij wybrane (tylko klient)

3.1. Panel umo¿liwia wys³anie zg³oszenia chêci wynajêcia/kupna mieszkania. Odbywa siê to nastepuj¹co: klient klika w rekord, sprawdza opis, zamyka okno z opisem, klika Kup/Wynajmij wybrane. W zg³oszeniu nale¿y wype³niæ pola takie, jak: Nazwa (klienta), numer telefonu, adres e-mail. Pole wybranego mieszkania jest uzupe³nione automatycznie. Po zatwierdzeniu, klient jest informowany o koniecznoœci rozpatrzenia zg³oszenia przez dewelopera (panel Przejrzyj zg³oszenia dla dewelopera).

4. Dodawanie og³oszenia (tylko deweloper)

4.1. Panel dodawania og³oszenia umo¿liwia dodanie mieszkania na sprzeda¿/do wynajêcia. Nale¿y uzupe³niæ dane takie, jak: nazwa, adres, koszt m2, powierzchnia m2, typ, piêtro. Mo¿na te¿ dodaæ informacjê o miejscu parkingowym w pakiecie z mieszkaniem.

5. Przegl¹danie zg³oszeñ (tylko deweloper)

5.1. Panel wyœwietla liste zg³oszeñ chêci kupna/wynajmu mieszkaæ przez klientów. Po wejsciu w dany rekord mamy informacjê i zainteresowanym kliencie, jego danych kontaktowych i wybranym mieszkaniu. 
5.2 Akceptacja zg³oszenia klienta odbywa sie przez zaznaczenie checkboxa ZatwierdŸ warunki wynajêcia/kupna i klikniêciu zapisz. Wyœwietlony zostanie monit Potwierdzenie. W tym miejscu mo¿na podejrzeæ, czy klient siê zgadza. W tym kroku nale¿y równie¿ wybraæ sposób wykorzystania (kupno lub wynajem). Je¿eli jest to wynajem, nale¿y ustawiæ datê koñca wynajmu. Po klikniêciu zatwierdŸ, og³oszenie znika z wyszukiwarki dla klientów, a w panelu wyszukiwarki dewelopera otrzymuje status Wynajête.

___________ Tabele ________________

1.House
id
name
cost_sm (square meter)
address
area_m (square meters)
housetype_id - slownik
level

2. Parking
id
address
house_id (null)
number (null)

3.Client
id
name
phone
email

4.FlatForClient
id
client_id
usetype_id
dateto - jezeli usetype_id == 'wynajem'
accepted (deweloper)
house_id


ENUM: HouseType (blok, dom jednorodzinny, dom wielorodzinny)

ENUM: FlatUseType (wynajem, kupno)