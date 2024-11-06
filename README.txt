eDnevnik


Desktop app:

Uloga: Admin, username:admin   Password:admin


Mobile app:

Uloga: Učenik, username:student1   Password:student

Za mobilnu aplikaciju bitno je napomenuti da ima više učenika, svim učenicima je ista šifra, a username može ići od 1 do 46

Prilikom pokretanja mobilne aplikacije, OBAVEZNO pokrenuti komandu .\setup_env.bat , kako bi se uspostavila ispravna konekcija sa Stripe sistemom plaćanja i kako bi se .env fajl popunio vrijednostima. Tu se OBAVEZNO moraju unijeti oba stripe ključa koja su navedena ispod (ili Vaši lični stripe ključevi).

Stripe:

stripePublishableKey: pk_test_51Q6vfBCNDstEqxgoz7ZTYrszPoD1ruRaN7ZaMkGojFXG9AXB12PajT9B5a0aMD4j9INswb7G65og24HEbMOQ5gHN00X1aWId4E

secretKey: sk_test_51Q6vfBCNDstEqxgoJxQw0CGVZ3HuN9ibEm1zGcvIqXAR5WptmAO2zA8h6BkiUNJv1coiitIZ13nmtzOC0NmShyyW002ECYHmCo