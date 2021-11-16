<template>
    <div class="home">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>

        <video controls="controls" preload="metadata">
            <source src="../assets/WatGebeurtErMetBloed.mp4#t=3.5" type="video/mp4">
            Your browser does not support the video tag.
        </video>

        <div class="text_homepage">

            <p>
                Iedereen die bij ons komt, heeft vragen over gezondheid. Vragen die wij beantwoorden met betrouwbare medische diagnostiek.
                Achter elke diagnose schuilt een persoonlijk verhaal. <strong class="black-text">Klik om meer te lezen.</strong>
            </p>

            <p>*Informatie over bloedprikken* <br><strong class="black-text">Klik om meer te lezen.</strong></p>

            <p>*Priklocaties* <br><strong class="black-text">Klik om meer te lezen.</strong></p>
        </div>
    </div>
</template>


<script>

</script>

<style scoped>
    .img {

        max-width: 100%;
        height: auto;
    }

    img {
        vertical-align: middle;
        border-style: none;
        width: 70%
    }

    .text_homepage {
        font-size: 70%;
        text-align: center;
        margin-top: 5%;
        margin-left: 8%;
        margin-right: 8%;
    }

    .homeButtons {
        margin-top: 4%;
        font-size: 70%;
    }

    .text_homepage p {
        cursor: pointer;
        padding: 1%;
        margin-top: 5%;
        margin-right: 10%;
        margin-left: 10%;
        border-radius: 15px;
        box-shadow: 0 0 10px 1px black;
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

</style>

