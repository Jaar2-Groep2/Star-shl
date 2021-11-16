<template>
    <div class="home">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>
        <h1>Hoofdscherm</h1>
        <video width="320" height="240" controls="controls" preload="metadata">
            <source src="../assets/WatGebeurtErMetBloed.mp4#t=3.5" type="video/mp4">
            Your browser does not support the video tag.
        </video>
        <div class="text_homepage">
            
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus maximus nisi vel dolor fermentum euismod. Ut dictum pellentesque sem, nec tristique tellus facilisis eu. Quisque commodo sem ipsum, vitae varius libero sollicitudin quis. In rhoncus feugiat ante, non viverra quam. Vivamus efficitur ligula ut odio sollicitudin posuere. Nam id tincidunt nisi. Donec eleifend ipsum ut odio porttitor, nec tempus lorem egestas. Curabitur pretium hendrerit mauris. Maecenas bibendum risus eros, eu pharetra sapien convallis et. Quisque sed purus sollicitudin, ultricies metus ut, pulvinar risus. Sed non sapien malesuada ligula dictum venenatis eget sit amet dui. Cras vitae arcu id tellus vestibulum ultricies. Praesent iaculis nulla vel dui tristique mollis. Quisque accumsan eu odio eget rutrum.
                   
        </div>
    </div>

    <div class="AdminLoginButton">
        <a class="grey-text" v-on:click="login()">
            Inloggen voor medewerkers
        </a>
    </div>

    <div class="Language">
        <a class="grey-text">
            <i class="material-icons">language</i>Land/Taal
        </a>
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

    .AdminLoginButton a {
        font-size: 10px;
        cursor: pointer;
    }

    .AdminLoginButton {
        margin-top: 6%;
        margin-bottom: 2%;
    }

    .Language {
        cursor: pointer;
    }

    .Language i {
            font-size: 15px;
    }

    .text_homepage{
        text-align: center;
        margin-left:15%;
        margin-right:15%;
    }
</style>

