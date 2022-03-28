# Biuro nieruchomości (EstateAgency)
## Podstawowe infromacje

![Biuro nieruchomości](https://kamilplowiec.tk/img/portfolio/csdesktop6.jpg)

1. Dodawanie, edycja, wyszukiwanie nieruchomości
2. Dodawanie, edycja, wyszukiwanie klientów
3. Mozliwość kupna lub wynajęcia mieszkania przez klienta (jeżeli wynajem, to na jaki okres)
4. Możliwość dołączenia miejsca parkingowego do mieszkania

## Opis działania

1. Logowanie do aplikacji odbywa sie przez wybór działania trybu programu (Deweloper lub Klient). Kliknięcie Zamknij zakończy działanie programu.

- Deweloper - osoba mająca możliwość dodawania ogłoszeń mieszkań, akceptacji zakupu/wynajmu mieszkania.
- Klient - anonimowa osoba, mogąca przeglądać ogłoszenia mieszkań i złożyć ofertę kupna/wynajmu.

2. Panel wyszukiwarki mieszkań

- Deweloper - ma możliwość wyszukiwania mieszkań według nazwy i adresu (wpisując w jednym polu). Widzi skrócone dane o mieszkaniu (nazwa, typ, piętro, cena, adres, czy ma parking) oraz czy mieszkanie jest już wynajęte/kupione. Kliknięcie w rekord umożliwia edycję danych ogłoszenia.

- Klient - ma możliwość wyszukiwania mieszkań według nazwy i adresu (wpisując w jednym polu). Widzi skrócone dane o mieszkaniu (nazwa, typ, piętro, cena, adres, czy ma parking). Kliknięcie w rekor umożliwia wyświetlenie pełnych informacji o mieszkaniu.

3. Kup/wynajmij wybrane (tylko klient)

- Panel umożliwia wysłanie zgłoszenia chęci wynajęcia/kupna mieszkania. Odbywa się to nastepująco: klient klika w rekord, sprawdza opis, zamyka okno z opisem, klika Kup/Wynajmij wybrane. W zgłoszeniu należy wypełnić pola takie, jak: Nazwa (klienta), numer telefonu, adres e-mail. Pole wybranego mieszkania jest uzupełnione automatycznie. Po zatwierdzeniu, klient jest informowany o konieczności rozpatrzenia zgłoszenia przez dewelopera (panel Przejrzyj zgłoszenia dla dewelopera).

4. Dodawanie ogłoszenia (tylko deweloper)

- Panel dodawania ogłoszenia umożliwia dodanie mieszkania na sprzedaż/do wynajęcia. Należy uzupełnić dane takie, jak: nazwa, adres, koszt m2, powierzchnia m2, typ, piętro. Można też dodać informację o miejscu parkingowym w pakiecie z mieszkaniem.

5. Przeglądanie zgłoszeń (tylko deweloper)

- Panel wyświetla liste zgłoszeń chęci kupna/wynajmu mieszkać przez klientów. Po wejsciu w dany rekord mamy informację i zainteresowanym kliencie, jego danych kontaktowych i wybranym mieszkaniu. 
- Akceptacja zgłoszenia klienta odbywa sie przez zaznaczenie checkboxa Zatwierdź warunki wynajęcia/kupna i kliknięciu zapisz. Wyświetlony zostanie monit Potwierdzenie. W tym miejscu można podejrzeć, czy klient się zgadza. W tym kroku należy również wybrać sposób wykorzystania (kupno lub wynajem). Jeżeli jest to wynajem, należy ustawić datę końca wynajmu. Po kliknięciu zatwierdź, ogłoszenie znika z wyszukiwarki dla klientów, a w panelu wyszukiwarki dewelopera otrzymuje status Wynajęte.

## Struktura bazy danych

| 1. House              | 2. Parking      | 3. Client  | 4. FlatForClient    |
| --------------------- | --------------- | ---------- | ------------------- |
| id                    | id              | id         | id                  |
| name                  | address         | name       | client_id           |
| cost_sm (square meter)| house_id (null) | phone      | usetype_id          |
| address               | number (null)   | email      | dateto              |
| area_m (square meters)|                 |            | accepted (deweloper)|
| housetype_id - slownik|                 |            | house_id            |
| level                 |                 |            |                     |


ENUMS:
- HouseType (blok, dom jednorodzinny, dom wielorodzinny)
- FlatUseType (wynajem, kupno)
