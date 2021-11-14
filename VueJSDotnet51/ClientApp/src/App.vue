

<!-- <button class="btn" v-on:click="login()">Login</button> -->

<script>
    import Sidebar from './components/Sidebar.vue'
    import { sidebarWidth } from './components/state'
    export default {
        components: { Sidebar },
        setup() {
            return { sidebarWidth }
        }
    }
</script>

<template>
    <Sidebar />
    <div :style="{ 'margin-left': sidebarWidth }">
        <router-view />
    </div>
</template>

<style>
    .btn {
        font-size: 20px;
        color: white;
        background: #e7334c;
        border-color: #121212;
        margin-top: 100px;
    }
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 20px;
        margin-left: 110px;
        margin-right: 20px;
        background-color: #e0edf5;
    }
    
</style>
