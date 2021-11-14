<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css">

    <div id="Secure">
        <img src="../assets/star-shl.jpg" />
        <h1>Medewerkersportaal</h1>

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

    <!-- Dropdown Trigger -->

    <a class='dropdown-trigger btn' href='#' data-target='dropdown1'><j class="material-icons">create</j>pagina bewerken</a>

    <!-- Dropdown Structure with materialize: does not work-->
    <ul id='dropdown1' class='dropdown-content'>
        <li><a href="#">Home-pagina bewerken</a></li>
        <li><a href="#">Informatie-pagina bewerken</a></li>
    </ul>

    <div class="dropdown"> <!-- dropdown structure with bootstrap: does not work-->
        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Dropdown button
        </button>
        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <a class="dropdown-item" href="#">Action</a>
            <a class="dropdown-item" href="#">Another action</a>
            <a class="dropdown-item" href="#">Something else here</a>
        </div>
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

    .Reservations a {
        font-size: 15px;
        margin: 1%; 
        width: 20%;
        border-radius: 15px;
    }

    .Reservations a i {
        font-size: 16px;
    }
    
    .a j {
        font-size: 20px;
    }

    .Edit_page_Button a{
        font-size: 15px;
        margin: 3%;
        width: 20%;
        border-radius: 15px;
    }
    .Editable_pages a {
        font-size: 15px;
        margin: 3%;
        width: 20%;
        border-radius: 15px;
    }
</style>