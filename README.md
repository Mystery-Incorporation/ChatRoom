# ChatRoom
    
  Chattklienten:
    Gör inget mer på Console-programmet! Gör i stället
    en WPF-klient i oktober. Den kan vara något krånglig att
    skapa - den skall
    
      1. ha en självuppdaterande logg (TextBlock) som kör i
         en bakgrundsprocess och visar meddelanden från
         servern, och så skall klienten
         
      2. ha en TextBox där man kan skriva in och sända
         meddelanden (sändknapp).
         
    Klienten kan skapas i två steg. Skapa först funk-
    tionaliteten 2!
    
    När ni skapar funktionaliteten 1, så skall den ha en
    egen klientidentitet uppkopplad. Den skall vara helt
    passiv, och BARA ligga och vänta på att få läsa 
    meddelanden från servern, den skall inte sända någonting,
    bara lägga upp meddelandena från servern i TextBlocket.
    
  Namn:
    Alla klienter skall vara kopplade till en person. När en
    klient i funktionalitet 2 ovan kopplar upp sig kan den
    skicka ett namn som det allra första meddelandet.
  Mellan olika datorer:
    Chattservern kan se ut som idag. Den tar emot meddelanden
    från vem som helst. Chattklienten måste dock anpassas.
    Ni gör förstås en clientSocket.Connect som i dagens
    Console-klient, men IPAddress.Loopback (den egna maskinen)
    måste bytas ut mot en riktig IPAddress, det går visst att
    skriva clientSocket.Connect("192.168.1.14", 8000);
  Portnummer:
    Använd aldrig ett portnummer lägre än 8000. Ni kan behöva
    släppa igenom trafik på 8000 i Windows brandväggar för att
    det skall funka - åtminstone på server-PC:n. Ni kan också
    (tillfälligt) stänga av brandväggen. Om ni byter portnummer
    så måste ni öppna det nya portnumret på datorn också.
