<template>
    <div id="Secure">
        <img src="../assets/star-shl.jpg" />
        <h1>Medewerkersportaal</h1>
        <p>
            Welkom Admin!
        </p>

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