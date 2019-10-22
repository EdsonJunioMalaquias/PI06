<template>
    <div class="card-style">
        <h1 class="title">{{ title }}</h1>
        <p>{{ content }}</p>
    </div>
</template>

<script>
export default { 
    name: 'Card',
    props: {title: String, content: String},
}
</script>

<style>
    body {
        background: #A1FFCE;  /* fallback for old browsers */
        background: -webkit-linear-gradient(to right, #FAFFD1, #A1FFCE);  /* Chrome 10-25, Safari 5.1-6 */
        background: linear-gradient(to right, #FAFFD1, #A1FFCE); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
        display: flex;
        flex-direction: column;
    }

    #container {
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        margin: auto;
        background: grey;
        width: 750px;
        opacity: .5;
        border-radius: 3px;
        padding: 10px;
    }

    .card-style {
        width: 100%;
        height: 300px;
        align-self: center;
        background: whitesmoke;
        padding: 5px;
        border-radius: 3px;
        margin: 10px 10px;
        font-family: monospace;
        transition: all .15s ease-in-out;
        overflow: scroll;

        
    }


</style>