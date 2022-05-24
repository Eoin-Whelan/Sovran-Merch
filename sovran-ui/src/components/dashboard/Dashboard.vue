<template>
    <section>
        <b-tabs v-if="authorized" v-model="activeTab" animated :multiline="multiline">
            <b-tab-item
                    v-if="true"
                    value="account"
                    id="account"
                    key="account"
                    label="Account Info"
                    displayed=true>
            </b-tab-item>
            <b-tab-item
                    v-if="true"
                    value="catalog"
                    id="catalog"
                    key="catalog"
                    label="Catalog"
                    displayed=true>
            </b-tab-item>
        </b-tabs>
    </section>
</template>

<script>
    export default {
        data() {
            return {
                activeTab: 'account',
                multiline: true
            }
        },
        props: ['authorized', 'username'],
        computed: {

        }
    }
</script>
