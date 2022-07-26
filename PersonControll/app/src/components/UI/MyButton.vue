<template>
    <button class="create btn1">
        <slot></slot>
    </button>
</template>

<script>
export default{
    name: 'my-button'
}
</script>

<style>
    .create {
        margin-top: 15px;
        margin-bottom: 15px;
        align-self: flex-end;
        padding: 10px 15px;
        color: rgb(255, 255, 255);
        background-image: linear-gradient(to bottom right, #0101ce, rgb(85, 120, 236)); 
        border-radius: 10%;
        border: 0px;   
    }

    .btn1:hover, .btn1:focus{
        transform: translateY(-3px);
    }

</style>