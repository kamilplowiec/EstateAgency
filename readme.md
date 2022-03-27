Biuro nieruchomo�ci (EstateAgency)

1. Dodawanie, edycja, wyszukiwanie nieruchomo�ci
2. Dodawanie, edycja, wyszukiwanie klient�w
3. Mozliwo�� kupna lub wynaj�cia mieszkania przez klienta (je�eli wynajem, to na jaki okres)
4. Mo�liwo�� do��czenia miejsca parkingowego do mieszkania

________Opis dzia�ania____________

1. Logowanie do aplikacji odbywa sie przez wyb�r dzia�ania trybu programu (Deweloper lub Klient). Klikni�cie Zamknij zako�czy dzia�anie programu.

1.1. Deweloper - osoba maj�ca mo�liwo�� dodawania og�osze� mieszka�, akceptacji zakupu/wynajmu mieszkania.
1.2. Klient - anonimowa osoba, mog�ca przegl�da� og�oszenia mieszka� i z�o�y� ofert� kupna/wynajmu.

2. Panel wyszukiwarki mieszka�

2.1. Deweloper - ma mo�liwo�� wyszukiwania mieszka� wed�ug nazwy i adresu (wpisuj�c w jednym polu). Widzi skr�cone dane o mieszkaniu (nazwa, typ, pi�tro, cena, adres, czy ma parking) oraz czy mieszkanie jest ju� wynaj�te/kupione. Klikni�cie w rekord umo�liwia edycj� danych og�oszenia.

2.2. Klient - ma mo�liwo�� wyszukiwania mieszka� wed�ug nazwy i adresu (wpisuj�c w jednym polu). Widzi skr�cone dane o mieszkaniu (nazwa, typ, pi�tro, cena, adres, czy ma parking). Klikni�cie w rekor umo�liwia wy�wietlenie pe�nych informacji o mieszkaniu.

3. Kup/wynajmij wybrane (tylko klient)

3.1. Panel umo�liwia wys�anie zg�oszenia ch�ci wynaj�cia/kupna mieszkania. Odbywa si� to nastepuj�co: klient klika w rekord, sprawdza opis, zamyka okno z opisem, klika Kup/Wynajmij wybrane. W zg�oszeniu nale�y wype�ni� pola takie, jak: Nazwa (klienta), numer telefonu, adres e-mail. Pole wybranego mieszkania jest uzupe�nione automatycznie. Po zatwierdzeniu, klient jest informowany o konieczno�ci rozpatrzenia zg�oszenia przez dewelopera (panel Przejrzyj zg�oszenia dla dewelopera).

4. Dodawanie og�oszenia (tylko deweloper)

4.1. Panel dodawania og�oszenia umo�liwia dodanie mieszkania na sprzeda�/do wynaj�cia. Nale�y uzupe�ni� dane takie, jak: nazwa, adres, koszt m2, powierzchnia m2, typ, pi�tro. Mo�na te� doda� informacj� o miejscu parkingowym w pakiecie z mieszkaniem.

5. Przegl�danie zg�osze� (tylko deweloper)

5.1. Panel wy�wietla liste zg�osze� ch�ci kupna/wynajmu mieszka� przez klient�w. Po wejsciu w dany rekord mamy informacj� i zainteresowanym kliencie, jego danych kontaktowych i wybranym mieszkaniu. 
5.2 Akceptacja zg�oszenia klienta odbywa sie przez zaznaczenie checkboxa Zatwierd� warunki wynaj�cia/kupna i klikni�ciu zapisz. Wy�wietlony zostanie monit Potwierdzenie. W tym miejscu mo�na podejrze�, czy klient si� zgadza. W tym kroku nale�y r�wnie� wybra� spos�b wykorzystania (kupno lub wynajem). Je�eli jest to wynajem, nale�y ustawi� dat� ko�ca wynajmu. Po klikni�ciu zatwierd�, og�oszenie znika z wyszukiwarki dla klient�w, a w panelu wyszukiwarki dewelopera otrzymuje status Wynaj�te.

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