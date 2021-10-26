<template>
    <h1 id="tableLabel">Database test</h1>

    <p>This component demonstrates fetching data from the server.</p>

    <p v-if="!databases"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="databases">
        <thead>
            <tr>
                <th>Username</th>
                <th>Passwords</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="database of databses" v-bind:key="database">
                <td>{{ database.username }}</td>
                <td>{{ database.passwords }}</td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "DataBase",
        data() {
            return {
                forecasts: []
            }
        },
        methods: {
            getDatabase() {
                axios.get('/sqltest')
                    .then((response) => {
                        this.databases = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getDatabase();
        }
    }
</script>