
<script>
    export default {
        name: "info",
        data() {
            return {
                infopage: 1,
            };
        },


        methods: {
            toggleOne: function () {
                this.infopage = 1;
            },
            toggleTwo: function () {
                this.infopage = 2;
            },
            toggleThree: function () {
                this.infopage = 3;
            },
            toggleFour: function () {
                this.infopage = 4;
            },
        }
    };


</script>



<template>
    <div class="info">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>

        <div>
            <a v-on:click=toggleOne() class="info btn">Over Star-shl</a>
            <a v-on:click=toggleTwo() class="info btn">Innovatie</a>
            <a v-on:click=toggleThree() class="info btn">Vrijwilligersbeleid</a>
            <a v-on:click=toggleFour() class="info btn">Kwaliteit</a>
        </div>


        <div class="text_info">
            <p v-show="infopage === 1">
                Iedereen die bij ons komt, heeft vragen over gezondheid. Vragen die wij beantwoorden met betrouwbare medische diagnostiek.
                Achter elke diagnose schuilt een persoonlijk verhaal. Daarom geloven wij dat elke vraag onze speciale aandacht verdient voor een helder en betrouwbaar antwoord.<br><br>
                We zijn gespecialiseerd in laboratoriumonderzoek van bloed, urine en ontlasting.
                Ook voeren we beeldvormend- en functieonderzoek uit zoals röntgen, echo’s en oogfoto’s en doen we onderzoek naar hart- en longfuncties.
                Onze trombosedienst begeleidt jaarlijks ruim 30.000 patiënten bij het gebruik van antistollingsmiddelen.
                Onze locaties voor bloedafname en andere onderzoeken zitten verspreid over Zuidwest-Nederland en daardoor zijn we altijd dichtbij.
                En als het nodig is, komen we bij de mensen thuis.<br><br>
                Medewerkers van Star-shl ondersteunen en adviseren professionals zoals huisartsen, verloskundigen en zorginstellingen. 
                Onze ervaren praktijkondersteuners begeleiden in tal van huisartsenpraktijken patiënten met chronische aandoeningen.
            </p>
            <p v-show="infopage === 2">
                Met trots presenteren wij u het innovatiejaarbericht van 2020!
                In dit jaarbericht leest u kort en bondig welke innovatieve projecten Star-shl in 2020 heeft opgestart en wat er is bereikt.<br><br>
                De coronacrisis laat natuurlijk diepe sporen na in onze samenleving en in de zorg. Het was voor Star-shl een uitdaging om diagnostiek veilig en toegankelijk te houden in 2020. We realiseerden in rap tempo bloedafname op afspraak, diverse vormen van COVID-19 diagnostiek, en we richten onze diensten en prikposten COVID bestendig in. Vele aanvragers gaven aan dat we op deze wijze goed aansloten bij hun behoeften en die van de patiënten. Door de coronacrisis hebben een aantal geplande innovaties vertraging opgelopen en zijn juist andere projecten en diensten razendsnel ontwikkeld. In dit innovatiejaarbericht ziet u ook innovaties die een direct gevolg zijn van de coronacrisis. Deze ervaringen nemen we mee in het nieuwe jaar en met meer focus om samen te vernieuwen en te innoveren.<br>
                Want Star-shl kijkt graag vooruit en wil voorop lopen in de ontwikkeling van diagnostiek en zorg. Zowel in het nieuwe state-of-the-art laboratorium als in ons kenniscentrum staan snelle, efficiënte en betrouwbare diagnostiek voor de patiënt centraal. Dit doen we door te investeren in innovatie, kennis te delen en nieuwe toepassingen te ontwikkelen. Door te participeren in wetenschappelijke onderzoeken en in nieuwe samenwerkingen binnen de gehele zorgketen zullen we ook in 2021 innovatieprojecten opzetten en andere afronden.
            </p>
            <p v-show="infopage === 3">
                Een brede dienstverlening en uitstekende medische diagnostiek; dat wil Star-shl haar patiënten bieden. Star-shl heeft naast deskundigheid op het gebied van diagnostiek en het verlenen van goede service naar patiënten, maatschappelijke betrokkenheid hoog in het vaandel. Door vrijwilligers in te zetten op ondersteunende diensten, bieden we onze patiënten een extra helpende hand en kunnen mensen die vrijwillig een bijdrage willen leveren aan de zorg, dit ook daadwerkelijk doen!<br>
                We merken regelmatig dat patiënten tijdens een bezoek aan een van onze locaties extra aandacht kunnen gebruiken. De zorg is een drukke omgeving, er gebeurt veel en alles gaat snel. Patiënten die binnenkomen zijn vaak al wat gespannen. Door aandacht van onze vrijwilligers, proberen we de wachttijd aangenamer te maken.<br><br>
                Kortom: onze vrijwilligers zijn een belangrijke schakel in de totale kwaliteit van onze zorg en dienstverlening; een extra hulp voor patiënten en ze ondersteunen de zorgprofessionals in onze organisatie die zich volledig kunnen richten op het daadwerkelijke onderzoek of de bloedafname.
            </p>
            <p v-show="infopage === 4">
                Star-shl staat voor kwalitatief hoogwaardige medische- en laboratoriumdiagnostiek en haar kwaliteitsmanagementsysteem is gebaseerd op de volgende internationale normen:<br><br>
                ISO-15189 (Medische laboratoria – bijzondere eisen voor kwaliteit en competentie) en ISO-22870 (Point of Care Testing/POCT)<br><br>
                ISO 27001 (Informatietechnologie - Beveiligingstechnieken - Managementsystemen voor informatiebeveiliging) en tevens op de nationale NEN 7510 norm (Medische informatica – Informatiebeveiliging in de zorg).<br>
            </p>
        </div>


    </div>

    <footer>
        <p class="text-white">
            <strong>Etten-Leur</strong><br>
            Bredaseweg 165, 4872 LA<br>
            Postbus 228, 4870 AE<br>
            <br>
            <strong>Rotterdam</strong><br>
            Vlambloem 21, 3068 JE<br>
            Postbus 8661, 3009 AR<br>
        </p>
    </footer>
</template>



<style>
    .btn:hover {
        opacity: 1;
    }

    .btn {
        color: white;
    }
</style>

<style scoped>
    .img {
        vertical-align: middle;
        border-style: none;
    }
    img {
        vertical-align: middle;
        border-style: none;
        width: 800px;
        max-width: 90%;
    }

    img {
        vertical-align: middle;
        border-style: none;
        width: 800px;
        max-width: 80%;
    }

    .text_info {
        font-size: 12px;
        text-align: center;
        margin-top: 5%;
        margin-left: 8%;
        margin-right: 8%;
    }

    .text_info p {
        cursor: pointer;
        padding: 4%;
        margin-right: 10%;
        margin-left: 10%;
        margin-bottom: 12%;
        border-radius: 15px;
        box-shadow: 0 0 10px 1px black;
        text-align: left;
    }

    video {
        margin-top: 10px;
        width: 640px;
        height: 360px;
    }   


    @media screen and (max-width: 700px) {
        video {
            width: 320px;
            margin-top: 10px;
            height: 240px;
        }
    }

    .homeButtons {
        background: #E91E63;
        border: hidden;
        padding: 2%;
        font-size: 60%;
        border-radius: 15px;
        width: 60%;
        margin: 1.5%;
    }

    .blue {
        background: #2C2B64;
    }


    footer {
        margin-top: 5%;
        background: #2C2B64;
        padding: 5%;
        padding-left: 8%;
    }

    footer p {
        text-align: left;
        font-size: 50%;
    }

    .btn {
        opacity: 0.6;
        margin-top: 40px;
    }

</style>

