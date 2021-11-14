<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css">
    <div id="Secure">
        <img src="../assets/star-shl.jpg" />
        <h1>Medewerkersportaal</h1>
        <p>
            Welkom Admin!
        </p>

    </div>

    <!-- Compiled and minified JavaScript -->
    <div class="ContinueButton">
        <a class="waves-effect waves-light btn pink lighten-2 white-text hoverable">
            reservering toevoegen<i class="material-icons">create</i>
        </a>
    </div>

    <div class="ContinueButton">
        <a class="waves-effect waves-light btn pink lighten-2 white-text hoverable">
            reservering annueleren<i class="material-icons">create</i>
        </a>
    </div>

    <div class="Edit_page">
        <a class="waves-effect waves-light btn pink lighten-2 white-text hoverable">
            pagina bewerken<i class="material-icons">create</i>
        </a>
    </div>
</template>


<script>
    export default {
        name: 'Secure',
        emits: ["authenticated", "setAuthenticated"],
        data() {
            return {};
        }
    }
</script>

<style scoped>
    #Secure {

    }
    .ContinueButton a {
        font-size: 15px;
        margin-top: 5%;
        width: 15%;
        border-radius: 7px;
    }

    .Edit_page{
        font-size: 15px;
        margin-top: 5%;
        width: 15%;
        border-radius: 7px;
    }
</style>