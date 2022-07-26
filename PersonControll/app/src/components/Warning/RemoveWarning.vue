<template>
    <div v-if="show" class="modal-shadow">
        <my-draggable>
            <template v-slot:header>
                <h1 class="invisible">
                    Тут необходим текст
                </h1>
            </template>
            <template v-slot:main>
                <div class="modal-content">
                    <form @submit.prevent>
                        <h2>Изменить данные?</h2>
                    </form>
                </div>
            </template>
            <template v-slot:footer>
                <div class="modal-footer">
                    <my-button class="create" @click="updateDate">Подтвердить</my-button>
                    <my-button class="create" @click="closeModalRemPost">Отменить</my-button>
                </div>
            </template>
        </my-draggable>
        <NotRemove ref="notRemoveModal"></NotRemove>
        <YesRemove ref="yesRemoveModal" @closeAllModal="closeAll__Modal"></YesRemove>
        <remove-post-vue ref="modal"></remove-post-vue>
    </div>
</template>

<script>
import axios from 'axios';
import YesRemove from './YesRemove.vue';
import NotRemove from './notRemove.vue';

export default {
    components: {
        YesRemove,
        NotRemove
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
        },
        closeAll__Modal() {
            this.$emit('closeAllModal');
            this.show = false
        },
        closeModalRemPost() {
            this.show = false;
        },
        async updateDate() {
            const formatDate = (date) => {
                let d = new Date(date);
                let month = (d.getMonth() + 1).toString();
                let day = d.getDate().toString();
                let year = d.getFullYear();
                if (month.length < 2) {
                    month = '0' + month;
                }
                if (day.length < 2) {
                    day = '0' + day;
                }
                return [day, month, year].join('.');
            }
            try {
                const responce = await axios.get('https://localhost:44310/EditTableColumn/UpdateColumn?id=' + this.id + '&surname=' +
                    this.surname + '&firstname=' + this.firstname +
                    '&lastname=' + this.lastname + '&birthday=' +
                    formatDate(this.birthday) + '');
                console.log(responce);
                this.$refs.yesRemoveModal.show = true;
            } catch (e) {
                this.$refs.notRemoveModal.show = true;
            }
        }
    },
    props: {
        id: String,
        surname: String,
        lastname: String,
        firstname: String,
        birthday: String
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
    top: 50%;
    left: 50%;
    width: 500px;
    height: 300px;
    margin-left: -250px;
    margin-top: -250px;
    background: rgba(0, 0, 0, 0);
}

.invisible {
    visibility: hidden !important;
}
</style>