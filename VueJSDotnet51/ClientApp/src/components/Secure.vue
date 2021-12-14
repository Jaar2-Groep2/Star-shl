<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />

    <div id="Secure">
        <!-- star shl banner-->
        <img src="../assets/star-shl.jpg" />
    </div>

    <div class="headline">
        <!-- Headline text-->
        <h2 style="font-size:6vw">Medewerkersportaal</h2><br>
    </div>

    <div class="Reservation_add Reservations">
        <!-- Reservation add-->
        <a class="btn" v-on:click="addReservation()">
            <i class="material-icons">add_circle</i> Afspraak toevoegen
        </a>
    </div>

    <div class="Reservation_delete Reservations">
        <!-- Reservation delete-->
        <a class="btn">
            <i class="material-icons">delete</i> Afspraak verwijderen
        </a>
    </div>

    <div class="reservation_check Reservations">
        <!-- Reservation check-->
        <a class="btn">
            <i class="material-icons">visibility</i> Afspraak inzien
        </a>
    </div>

    <div class="Editable Reservations">
        <!-- Information page edit button -->
        <a class="btn">
            <i class="material-icons">edit</i>Informatiepagina bewerken
        </a>
    </div>

    <div class="Editable Reservations">
        <!-- Home page edit button -->
        <a class="btn">
            <i class="material-icons">edit</i>Homepagina bewerken
        </a>
    </div>

</template>


<script>
    export default {
        methods: {
            addReservation() {
                this.$router.replace({ name: "AddReservation" });
            }
        }
    }

</script>

<style scoped>
    #Secure {
    }

    img {
        vertical-align: middle;
        border-style: none;
        width: 60%;
        margin-bottom: 3%
    }

    .Reservations a i {
        font-size: calc(6px + 1.5vw);
    }

    .Reservations a {
        background: #e7334c;
        border: hidden;
        padding: 15px;
        font-size: calc(6px + 1.5vw);
        font-weight: bold;
        border-radius: 15px;
        width: calc(50% + 1.5vw);
        margin: 1.5%;
    }

    .Editable a {
        background: #79b9d5;
    }
</style>