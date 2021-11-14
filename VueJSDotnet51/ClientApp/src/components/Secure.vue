<template>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">

    <div id="Secure">
        <img src="../assets/star-shl.jpg" />
        <h1>Medewerkersportaal</h1>
        <p>
            Welkom Admin!
        </p>
    </div>

    <div class="Reservations">
        <a class="add waves-effect waves-light btn pink lighten-2 white-text hoverable">
            <i class="material-icons">create</i> Reservering toevoegen
        </a>

        <a class="remove waves-effect waves-light btn pink lighten-2 white-text hoverable">
            <i class="material-icons">create</i> Reservering verwijderen
        </a>

        <a class="see waves-effect waves-light btn pink lighten-2 white-text hoverable">
            <i class="material-icons">create</i> Reserveringen inzien
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

    .Reservations a {
        font-size: 15px;
        margin: 3%; 
        width: 20%;
        border-radius: 15px;
    }

    .Reservations a i {
        font-size: 15px;
    }
</style>