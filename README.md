# ProjektIS

## Ime seminarske naloge:
Dokumenti

## Člana seminarske naloge:
Martin Simčič 63190035 
Klemen Parkelj 63220239

## Opis spletne aplikacije:

Najina spletna aplikacija omogoča hranjenje metapodatkov o dokumentih, ki jih lahko vanjo vnašamo. Ustvarjena je na osnovi konceptov ki smo jih spoznali na vajah, to so ASP.NET, MVC, Microsoft Azure... Domača stran vsebuje menije, kjer lahko dodajamo dokumente, tipe dokumentov in avtorje dokumentov. Uporabniki se delijo na tri kategorije, superadmin, admin in user. Superadmin lahko počne vse, admin ne more izbrisati dokumentov in ne more dodajati avtorjev, user pa lahko samo dodaja dokumente in pogleda njihove detajle. 
![Domača stran aplikacije](https://github.com/klemenp950/ProjektIS/blob/main/Images/Spletna%20aplikacija.png)

Seznam dokumentov se nahaja pod zavihkom dokumenti. Na podoben način so izpisani tudi avtorji in tipi datotek.

![Seznam dokumentov](https://github.com/klemenp950/ProjektIS/blob/main/Images/Spletna%20aplikacija%20dokumenti.png)

Spletna aplikacija gostuje na storitvi Microsoft Azure. 

Baza spletne aplikacije izgleda tako:

![Baza](https://github.com/klemenp950/ProjektIS/blob/main/Images/Posnetek%20zaslona%202024-01-16%20223329.png)

## Opis API

Spletna aplikacija ima tudi API. API je zavarovan s tokenom, tako da ne mora kdorkoli dostopati do dokumentov ali pa jih dodajati. Dokumentacija je navoljo na [swagger-ju](https://dokumenti.azurewebsites.net/swagger/index.html). 

![swagger](https://github.com/klemenp950/ProjektIS/blob/main/Images/swagger.png)

## Opis mobilne aplikacije 

Mobilna aplikacija je navoljo na tem [naslovu](https://github.com/klemenp950/AplikacijaIS) Ob pritisku na gumb prikaži dokumente aplikacija izpiše imena dokumentov, število znakov in datum in uro ustvarjanja datoteke. Te podatke pridobi s pomočjo GET zahtevka. 

![Prikaži dokumente](https://github.com/klemenp950/ProjektIS/blob/main/Images/Aplikacija1.jpg)

S pritiskom na gumb Vnesi dokument se odpre novo okno kamor lahko vnesemo podatke o dokumentu ki ga želimo dodati. Ta se doda v bazo s pomočjo zahtevka POST.

![Prikaži dokumente](https://github.com/klemenp950/ProjektIS/blob/main/Images/Aplikacija2.jpg)

## Razdelitev dela
Skupaj sva naredila večji del spletne aplikacije. Za ustvarjanje API-ja je bil zadolžen Klemen, za njegovo avtentikacijo pa Martin. Mobilno aplikacijo sva ponovno delala skupaj. Večjih projektov torej mobilne in spletne aplikacije sva se lotila tako da sva se dobila v živo in delala skupaj, v github je datoteke dodajal Klemen. 
