<template>
    <div id="Secure">
        <img src="../assets/star-shl.jpg" />
        <h1>Medewerkersportaal</h1>
        <p>
            Welkom Admin!
        </p>
        <button class="btn"> <!-- button to swith to Admindashboard-->
            <v-btn></v-btn>
            <router-link to="Admindashboard">Admindashboard</router-link>
        </button>

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
</style>