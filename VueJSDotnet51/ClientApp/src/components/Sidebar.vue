<script>
    export default {
        name: "sidebar",
            data() {
                return {
                    scrollPosition: null,
                    mobile: true,
                    mobileNav: true,
                    windowWidth: null,
                    width: 0,
                    height: 0,
                };
            },

            created() {
                window.addEventListener("resize", this.checkScreen);
                this.checkScreen();
            },

            methods: {
                toggleMobileNav: function()   {
                    this.mobileNav = !this.mobileNav;
                },

                checkScreen: function()   {
                    this.windowWidth = window.innerWidth;
                    this.width = window.innerWidth;
                    this.height = window.innerHeight;
                    if (this.windowWidth <= 750) {
                        this.mobile = true;
                        this.mobileNav = false;
                        return;
                    }
                    this.mobile = false;
                    this.mobileNav = false;
                    return;
                },

                show: function () {
                    return "Welcome!"
                }
        }
    };


</script>

<template>
    <!--idebarLink to="/" icon="fas fa-home fa-2x">Home</SidebarLink>
    <SidebarLink to="/login" icon="fas fa-key fa-2x">Login</SidebarLink>
    <SidebarLink to="/analytics" icon="fas fa-chart-bar fa-2x">Analytics</SidebarLink>
    <SidebarLink to="/friends" icon="fas fa-user-friends fa-2x">Friends</SidebarLink>
    <SidebarLink to="/image" icon="fas fa-images fa-2x">Images</SidebarLink>-->
    <header :class="{ 'scrolled-nav' : scrollPosition}">
        <ul v-show="!mobile" class="nav">
            <li><router-link class="link" :to="{name: 'Home'}">Home</router-link></li>
            <li><router-link class="link" :to="{name: 'Login'}">Login(test)</router-link></li>
            <li><router-link class="link" :to="{ name: 'PDF' }">Bloedprik certificaat</router-link></li>
            <li><router-link class="link" :to="{name: 'Priklocaties' }">Priklokaties</router-link></li>
            <li><router-link class="link" :to="{name: 'Info'}">Informatie</router-link></li>
            <li><router-link class="link" :to="{name: 'EditorArjan'}">EditorArjan</router-link></li>
            

        </ul>
        <div class="toggle">
            <i v-on:click=toggleMobileNav() v-show="mobile" class="fas fa-bars fa-2x" style="color: white" v-bind:class="{ 'toggle-active': mobileNav}"></i>
        </div>
        <transition name="slide">
            <ul v-show="mobileNav" class="nav-dropdown">
                <!--v-on:click=toggleMobileNav()-->
                <li><router-link class="link2" :to="{name: 'Home'}">Home</router-link></li>
                <li><router-link class="link2" :to="{name: 'Login'}">Login(test)</router-link></li>
                <li><router-link class="link2" :to="{ name: 'PDF' }">Bloedprik certificaat</router-link></li>
                <li><router-link class="link2" :to="{name: 'Priklocaties'}">Priklocaties</router-link></li>
                <li><router-link class="link2" :to="{name: 'Info'}">Informatie</router-link></li>
                <li><router-link class="link2" :to="{name: 'EditorArjan'}">EditorArjan</router-link></li>

            </ul>
        </transition>
    </header>

</template>

<style>
    :root {
        --sidebar-bg-color: #002c40;
        --sidebar-item-hover: #4abad7;
        --sidebar-item-active: #fd334b;
    }
    .sidebar    {
        position: fixed;
    }
</style>

<style scoped>


    header{
        background-color: black;
        z-index: 99;
        width: 110%;
        position: fixed;
        transition: 0.5s ease all;
        color: white;
        top: 0;
    }

    .nav {
        display: flex;
        flex-direction: row;
        padding: 12px 0;
        transition: 0.5s ease all;
        width: 90%;
        margin: 0 auto;
        align-items: center;
    }


    .nav-dropdown {
        display: flex;
        flex-direction: column;
        position: fixed;
        width: 100%;
        max-width: 200px;
        height: 100%;
        background-color: white;
        top: 34px
    }

    ul {
        list-style: none;
        padding-left: 0;
    }

    li {
        text-align: center;
        background-clip: content-box;
        box-sizing: content-box;
        align-items: center;
        transition: 0.5s ease all;
        padding-right: 20px;
        
    }

        li :hover {
            background-color: #fd334b;
        }

    .slide-enter-active,
    .slide-leave-active{
        transition: 0.6s ease all;
    }

    .slide-enter-from,
    .slide-leave-to{
        transform: translateX(-250px);
    }

    .slide-enter-to {
        transform: translateX(0);
    }

    .link {
        display: block;
        font-weight: 500;
        font: 12px;
        color: white;
        list-style: none;
        text-decoration: none;
        font-size: 14px;
        transition: 0.5s ease all;
        text-align: center;
        vertical-align: middle;
        padding-top: 20px;
        width: 200px;
        padding: 20px 0;
    }

    .link2 {
        display: block;
        font-weight: 500;
        font: 12px;
        color: black;
        list-style: none;
        text-decoration: none;
        font-size: 14px;
        transition: 0.5s ease all;
        text-align: center;
        vertical-align: middle;
        padding-top: 20px;
        width: 200px;
        padding: 20px 0;
    }

    

    .toggle {
        float: left;
        margin-left: 10px;
        cursor: pointer;
        transition: 1s ease all;
    }

    .toggle-active {
        transition: 1s ease all;
        transform: scale(1);
    }

 
</style>