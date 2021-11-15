<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />
    
    <div class="headline">
        <h2 style="font-size:7vw">Medewerkersportaal</h2>
    </div>
    <div id="Secure">
        <img src="../assets/star-shl.jpg" /> 

    </div>
    <div class="Reservations">
        <a class="btn">
            <i class="material-icons">add_circle</i> Reservering toevoegen
        </a>

        <a class="btn">
            <i class="material-icons">delete</i> Reservering verwijderen
        </a>

        <a class="btn">
            <i class="material-icons">visibility</i> Reserveringen inzien
        </a>
    </div>

    <div class="Editable_pages Reservations">
        <a class="btn">
            Informatiepagina bewerken
        </a>
        <a class="btn">
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
        margin-bottom: 15%
    }

    .Reservations a i {
        font-size: 16px;
    }

    .Reservations a {
        background: #e91e63;
        border: hidden;
        font-size: 50%;
        border-radius: 15px;
        width: 60%;
        margin: 3%;
    }

    .Editable_pages a {
        background: #00c853;
    }
</style>