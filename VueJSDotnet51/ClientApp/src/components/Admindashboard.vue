<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">


    <div id="example-1">
        <a class="reservering_toevoegen">Reserveringen toevoegen</a>
    </div>
    <div id="example-2">
        <a class="reservering_annuleren">Reservering annuleren</a>
    </div>
    <div class="ContinueButton">
        <a class="waves-effect waves-light btn pink lighten-2 white-text hoverable" v-on:click="login()">
            Ga door
        </a>
    </div>
    <i class="material-icons">create</i>
</template>


<script>
    export default {

    }
</script>

<style scoped>
    .reservering_toevoegen{
        background: #e7334c;
        color: white;
        border: 10px;
        border-radius: 35px;
        padding: 10px;
        font-size: 16px;
    }
    .reservering_annuleren {
        background: #e7334c;
        color: white;
        border: 10px;
        border-radius: 35px;
        padding: 10px;
        font-size: 16px;
    }
    .ContinueButton a {
        font-size: 15px;
        margin-top: 11%;
        width: 15%;
        border-radius: 7px;
    }

</style>