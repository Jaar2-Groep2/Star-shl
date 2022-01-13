<template>
    <div>
        <h1 class="headline">Email is verstuurt</h1>
        <br>
        <p>U wordt in 5 seconden terugverzonden naar de homepagina</p>
    </div>
</template>


<script>
    export default {
        created(){
            setTimeout( () => this.$router.push({ path: '/Home'}), 5000);

        }
    }
</script>

<style scoped>
    .headline {
        font-size: calc(20px + 1.5vw);
        margin-top: 3%
    }
</style>