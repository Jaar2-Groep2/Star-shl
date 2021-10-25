<template>
    <div id="Secure">
        <h1>Medewerkersportaal</h1>
        <p>
            Medewerkersportaal Star-shl
        </p>

    </div>
    <img src="../assets/star-shl.jpg" />
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
        background-color: #FFFFFF;
        border: 1px solid #CCCCCC;
        padding: 20px;
        margin-top: 10px;
    }
</style>