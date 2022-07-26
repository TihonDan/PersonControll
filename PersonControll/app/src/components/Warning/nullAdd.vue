<template>
    <div v-if="show" class="modal-shadow" >
        <div>
            <my-draggable>
                <template v-slot:header>
                    <div class="test">
                        <h1 class="test-title">
                            Заполнение header
                        </h1>
                    </div>
                </template>
                <template v-slot:main>
                    <div class="modal-content">
                        <form @submit.prevent>
                            <h2>Все поля должны быть заполнены</h2>
                        </form>
                    </div>
                </template>
                <template v-slot:footer>
                    <div class="modal-footer">
                        <my-button class="create" @click="closeModal">Ок</my-button>
                    </div>
                </template>
            </my-draggable>
        </div>
    </div>
</template>

<script>


export default {

    components: {
    },
    name: "ModalWindow",
    data: function () {
        return {
            show: false
        }
    },
    methods: {
        closeModal: function () {
            this.show = false
        }
    }
}
</script>

<style scoped>
form {
    display: flex;
    flex-direction: column;
}

.modal-shadow {
    position: absolute;
    top: 0;
    left: 0;
    min-height: 100%;
    width: 100%;
    background: rgba(22, 1, 1, 0.9);
}

h2 {
    margin-top: 15px;
    margin-bottom: 15px;
    align-self: center;
    padding: 10px 15px;
    color: teal;
    border: 1px solid teal;
}

.test-title{
    visibility: hidden !important;
}
</style>
