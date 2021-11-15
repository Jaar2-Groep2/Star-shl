<template>
    <div class="home">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>
        <h1>Hoofdscherm</h1>
        <video width="320" height="240" controls="controls" preload="metadata">
            <source src="../assets/WatGebeurtErMetBloed.mp4#t=3.5" type="video/mp4">
            Your browser does not support the video tag.
        </video>
        <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus maximus nisi vel dolor fermentum euismod. Ut dictum pellentesque sem, nec tristique tellus facilisis eu. Quisque commodo sem ipsum, vitae varius libero sollicitudin quis. In rhoncus feugiat ante, non viverra quam. Vivamus efficitur ligula ut odio sollicitudin posuere. Nam id tincidunt nisi. Donec eleifend ipsum ut odio porttitor, nec tempus lorem egestas. Curabitur pretium hendrerit mauris. Maecenas bibendum risus eros, eu pharetra sapien convallis et. Quisque sed purus sollicitudin, ultricies metus ut, pulvinar risus. Sed non sapien malesuada ligula dictum venenatis eget sit amet dui. Cras vitae arcu id tellus vestibulum ultricies. Praesent iaculis nulla vel dui tristique mollis. Quisque accumsan eu odio eget rutrum.
        </p>
    </div>
</template>


<script>
    export default {
        name: 'home',
        emits: ["authenticated", "setAuthenticated"],
        components: {},
    };
</script>

<style scoped>
    .img {

        max-width: 100%;
        height: auto;
    }

    img {
        vertical-align: middle;
        border-style: none;
        width: 70%
    }
</style>

