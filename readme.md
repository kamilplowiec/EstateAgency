Biuro nieruchomości (EstateAgency)

![Biuro nieruchomości](https://kamilplowiec.tk/img/portfolio/csdesktop6.jpg)

1. Dodawanie, edycja, wyszukiwanie nieruchomości
2. Dodawanie, edycja, wyszukiwanie klientów
3. Mozliwość kupna lub wynajęcia mieszkania przez klienta (jeżeli wynajem, to na jaki okres)
4. Możliwość dołączenia miejsca parkingowego do mieszkania

________Opis działania____________

1. Logowanie do aplikacji odbywa sie przez wybór działania trybu programu (Deweloper lub Klient). Kliknięcie Zamknij zakończy działanie programu.

1.1. Deweloper - osoba mająca możliwość dodawania ogłoszeń mieszkań, akceptacji zakupu/wynajmu mieszkania.
1.2. Klient - anonimowa osoba, mogąca przeglądać ogłoszenia mieszkań i złożyć ofertę kupna/wynajmu.

2. Panel wyszukiwarki mieszkań

2.1. Deweloper - ma możliwość wyszukiwania mieszkań według nazwy i adresu (wpisując w jednym polu). Widzi skrócone dane o mieszkaniu (nazwa, typ, piętro, cena, adres, czy ma parking) oraz czy mieszkanie jest już wynajęte/kupione. Kliknięcie w rekord umożliwia edycję danych ogłoszenia.

2.2. Klient - ma możliwość wyszukiwania mieszkań według nazwy i adresu (wpisując w jednym polu). Widzi skrócone dane o mieszkaniu (nazwa, typ, piętro, cena, adres, czy ma parking). Kliknięcie w rekor umożliwia wyświetlenie pełnych informacji o mieszkaniu.

3. Kup/wynajmij wybrane (tylko klient)

3.1. Panel umożliwia wysłanie zgłoszenia chęci wynajęcia/kupna mieszkania. Odbywa się to nastepująco: klient klika w rekord, sprawdza opis, zamyka okno z opisem, klika Kup/Wynajmij wybrane. W zgłoszeniu należy wypełnić pola takie, jak: Nazwa (klienta), numer telefonu, adres e-mail. Pole wybranego mieszkania jest uzupełnione automatycznie. Po zatwierdzeniu, klient jest informowany o konieczności rozpatrzenia zgłoszenia przez dewelopera (panel Przejrzyj zgłoszenia dla dewelopera).

4. Dodawanie ogłoszenia (tylko deweloper)

4.1. Panel dodawania ogłoszenia umożliwia dodanie mieszkania na sprzedaż/do wynajęcia. Należy uzupełnić dane takie, jak: nazwa, adres, koszt m2, powierzchnia m2, typ, piętro. Można też dodać informację o miejscu parkingowym w pakiecie z mieszkaniem.

5. Przeglądanie zgłoszeń (tylko deweloper)

5.1. Panel wyświetla liste zgłoszeń chęci kupna/wynajmu mieszkać przez klientów. Po wejsciu w dany rekord mamy informację i zainteresowanym kliencie, jego danych kontaktowych i wybranym mieszkaniu. 
5.2 Akceptacja zgłoszenia klienta odbywa sie przez zaznaczenie checkboxa Zatwierdź warunki wynajęcia/kupna i kliknięciu zapisz. Wyświetlony zostanie monit Potwierdzenie. W tym miejscu można podejrzeć, czy klient się zgadza. W tym kroku należy również wybrać sposób wykorzystania (kupno lub wynajem). Jeżeli jest to wynajem, należy ustawić datę końca wynajmu. Po kliknięciu zatwierdź, ogłoszenie znika z wyszukiwarki dla klientów, a w panelu wyszukiwarki dewelopera otrzymuje status Wynajęte.

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
