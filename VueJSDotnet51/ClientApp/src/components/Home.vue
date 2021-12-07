<template>
    <div class="home">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>

        <video controls="controls" preload="metadata">
            <source src="../assets/WatGebeurtErMetBloed.mp4#t=3.5" type="video/mp4">
            Your browser does not support the video tag.
        </video>

        <div class="headline">Over Star-shl</div>

        <div class="text_homepage">
            <h6>
                Iedereen die bij ons komt, heeft vragen over gezondheid. Vragen die wij beantwoorden met betrouwbare medische diagnostiek.
                Achter elke diagnose schuilt een persoonlijk verhaal.
                Daarom geloven wij dat elke vraag onze speciale aandacht verdient voor een helder en betrouwbaar antwoord.<br>
                <strong class="black-text">Klik om meer te lezen.</strong>
            </h6>
        </div>

        <router-link class="homeButtons btn" :to="{ name: 'Info' }">Informatie over onderzoeken</router-link>
        <a class="homeButtons btn">Afspraak maken</a>
        <router-link class="homeButtons btn" :to="{ name: 'Priklocaties' }">Priklokaties</router-link>
        <br><br>
        <a class="homeButtons blue btn">Contact</a>
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


<script>

</script>

<style>
    .btn:hover {
        opacity: 1.0;
    }

    .btn {
        color: white;
    }

    footer {
        margin-top: 5%;
        background: #142d49;
        padding: 5%;
        width: 100%;
        position: absolute;
    }

    footer p {
        text-align: left;
        font-size: 60%;
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

    .text_homepage {
/*        font-size: calc(8px + 0.5vw);*/
        text-align: center;
        margin-top: 1%;
        margin-left: 8%;
        margin-right: 8%;
    }
    .headline{
        font-size: calc(12px + 1.5vw);
        margin-top: 3%
    }

    .text_homepage h6 {
        cursor: pointer;
        padding: 3%;
        margin-right: 10%;
        margin-left: 10%;
        margin-bottom: 10%;
        border-radius: 15px;
        box-shadow: 0 0 10px 1px black;
        text-align: left;
        font-size: calc(8px + 1.0vw)
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
        background: #e7334c;
        border: hidden;
        padding: 2%;
        font-size: calc(8px + 1.0vw);
        font-weight: bold;
        border-radius: 15px;
        width: calc(50% + 1.0vw);
        margin: 1.5%;
    }

    .blue {
        background: #142d49;
    }

    .btn {
        opacity: 1.0;
    }

</style>

