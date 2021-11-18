

<!-- <button class="btn" v-on:click="login()">Login</button> -->

<script>
    import Sidebar from './components/Sidebar.vue'


    export default {
        components: { Sidebar },
    }
</script>

<template>
    <Sidebar />
    <div>
        <router-view />
    </div>
</template>

<style>
    .btn {
        font-size: 20px;
        color: white;
        background: #e7334c;
        border-color: #121212;
        margin-top: 140px;
    }
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        background-color: #e0edf5;
    }
    body {
        padding-top: 100px;
        background-color: #e0edf5;
    }

    @media only screen and (max-width: 600px) {
        body {
            padding-top: 50px;
            background-color: #e0edf5;
        }

    }
    
</style>
