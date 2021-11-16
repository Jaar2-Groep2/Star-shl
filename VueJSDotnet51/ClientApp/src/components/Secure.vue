<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />

    <div id="Secure">   <!-- star shl banner-->
        <img src="../assets/star-shl.jpg" />
    </div>
    
    <div class="headline">  <!-- Headline text-->
        <h2 style="font-size:6vw">Medewerkersportaal</h2>
    </div>
    
    <div class="Reservation_add Reservations">  <!-- Reservation add-->
        <a class="btn">
            <i class="material-icons">add_circle</i> Reservering toevoegen
        </a>
    </div>

    <div class="Reservation_delete Reservations">   <!-- Reservation delete-->
        <a class="btn">
            <i class="material-icons">delete</i> Reservering verwijderen
        </a>
    </div>

    <div class="reservation_check Reservations">    <!-- Reservation check-->
        <a class="btn">
            <i class="material-icons">visibility</i> Reserveringen inzien
        </a>
    </div>

    <div class="Editable Reservations">    <!-- Information page edit button -->
        <a class="btn">
            <i class="material-icons">edit</i>Informatiepagina bewerken
        </a>
    </div>

    <div class="Editable Reservations">    <!-- Home page edit button -->
        <a class="btn">
            <i class="material-icons">edit</i>Homepagina bewerken
        </a>
    </div>

</template>


<script>
    ////materialise code voor dropdown button niet toegepast
    //document.addEventListener('DOMContentLoaded', function () {
    //    var elems = document.querySelectorAll('.dropdown-trigger');
    //    var options = {alignment: 'left'}
    //    this.Dropdown.init(elems, options);
    //});


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
        font-size: 16px;
    }

    .Reservations a {
        background: #e91e63;
        border: hidden;
        padding: 15px;
        font-size: 50%;
        border-radius: 15px;
        width: 60%;
        margin: 1.5%;
    }

    .Editable a {
        background: #00c853;
    }

    .btn {
        opacity: 0.6;
    }
</style>