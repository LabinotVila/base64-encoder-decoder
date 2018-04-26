# Siguria e te Dhenave - Konvertimi ne Baze 64 me ane te DLL fajllit

Ky projekt paraqet mënyren e konvertimit të çfarë do teksti në tekst me bazë 64. Programi jonë funksionon në këtë mënyrë:
Së pari është shkruar funksioni i cili bën konvertimin e një numri në një numër binarë. Më pastaj, duke përdorur këtë funksion kemi 
shkruar funksionin i cili kthen tekstin në numra binarë me bazë 8 duke ia shtuar një padding që në rastin tonë është 0. Pas kësaj 
kemi shkruar funksionin që ndanë vargun e bitave me nga 6 dhe i kemi kthyer në numra decimal (0 - 63) e varësisht nga numri, duke i 
vendosur në funksionin fillestarë ne marrim stringun përfundimtarë. Më pas, kemi shtuar padding në tekstin tonë në mënyrë që dekriptimi 
të realizohet në mënyrë korrekte.

-Funksionet e implementuara ne DLL:

IntToBase64 (a) [a - numri] - kthen ne karakter me baz 64 nje numer. Ne rastin tone, numri nuk mund te jet me shume se 63!

ToBinary (a, b) [a - numri, b - interatori] - kthen vargun e bitave ne forme stringu te numrit.

StringToBinary (a) [a - fjala] - kthen ne numra binare te formes string nje tekst.

NdajeNga6 (a) [a - fjala] - ndane nga 6 bit vargun e bitave te formuar me larte.

paddIt (a) [a - fjalia] - mbulon fjaline nese nuk ka mjaftueshem bita.

toBase64 (a - fjalia] - funksioni final qe kthen fjaline ne baze 64.

Më pas, e kemi krijuar fajllin ekzekutiv me anë të së cilit importohet 'libraria' DLL si fajll referent dhe klonohet një objekt me anë 
të së cilit kryejmë të gjitha veprimet e nevojshme pa shkruar fare funksione në fajllin ekzekutiv.
