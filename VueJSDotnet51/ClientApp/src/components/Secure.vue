<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css">
    <div class="headline">
        <h2 style="font-size:7vw">Medewerkersportaal</h2>
    </div>
    <div id="Secure">
        <img src="../assets/star-shl.jpg" />

    </div>
    <div class="Reservations">
        <a class="add waves-effect waves-light btn pink lighten-2 white-text hoverable">
            <i class="material-icons">add_circle</i> Reservering toevoegen
        </a>

        <a class="remove waves-effect waves-light btn pink lighten-2 white-text hoverable">
            <i class="material-icons">delete</i> Reservering verwijderen
        </a>

        <a class="see waves-effect waves-light btn pink lighten-2 white-text hoverable">
            <i class="material-icons">visibility</i> Reserveringen inzien
        </a>
    </div>

    <div class="Editable_pages">
        <a class="see waves-effect waves-light btn green lighten-2 white-text hoverable">
            <p>Informatiepagina bewerken</p>
        </a>
        <a class="see waves-effect waves-light btn green lighten-2 white-text hoverable">
            Homepagina bewerken
        </a>
    </div>


</template>


<script>

    document.addEventListener('DOMContentLoaded', function () {
        var elems = document.querySelectorAll('.dropdown-trigger');
        var options = {alignment: 'left'}
        this.Dropdown.init(elems, options);
    });


</script>

<style scoped>
    #Secure {
    }
    img {
        vertical-align: middle;
        border-style: none;
        width: 60%;
    }

    .Reservations a {
        font-size: 70%;
        margin: 3%; 
        width: 60%;
        border-radius: 15px;
    }

    .Reservations a i {
        font-size: 16px;
    }
    
    .a j {
        font-size: 20px;
    }

    .Edit_page_Button a {
        font-size: 7vw;
        margin: 3%;
        width: 10%;
        border-radius: 15px;
    }
    .Editable_pages a {
        font-size: 70%;
        margin: 3%;
        width:60%;
        border-radius: 15px;
    }

</style>