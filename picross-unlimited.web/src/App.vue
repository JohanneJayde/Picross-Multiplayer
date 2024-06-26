<template>
  <v-app>
    <v-app-bar app flat class="border-md">
      <template v-slot:prepend>
        <v-app-bar-nav-icon @click="showDrawer = !showDrawer" />
      </template>

      <v-img src="/applogo.svg" alt="Logo" max-width="180" max-height="110" />
      <v-app-bar-title />

      <v-btn
        v-if="$vuetify.display.smAndUp"
        @click="showLoginLogOut"
        prepend-icon="mdi-account-cowboy-hat"
      >
        {{ tokenService.isLoggedIn() ? tokenService.getUserName() : 'Log In' }}
      </v-btn>
      <v-btn
        v-else
        @click="showLoginLogOut"
        :icon="tokenService.isLoggedIn() ? 'mdi-account' : 'mdi-login'"
      />
    </v-app-bar>
    <v-main>
      <RouterView />
    </v-main>
    <v-navigation-drawer v-model="showDrawer" location="left">
      <v-list>
        <v-list-item to="/About">About</v-list-item>
        <v-list-item to="/Puzzles">View Puzzles</v-list-item>
        <v-list-item to="/Player">Profile</v-list-item>
        <v-list-item to="/PuzzleEditor">Puzzle Creator</v-list-item>
      </v-list>
    </v-navigation-drawer>
    <SignInDialog v-model="showSignInDialog" />
    <ConfirmDialog
      v-model="showConfirmDialog"
      message="Are you sure you want to logout?"
      title="Log Out"
      action="Log Out"
      @updated="logout"
    />
  </v-app>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'
import { ref } from 'vue'
import TokenService from './scripts/tokenService'
import SignInDialog from '@/components/SignInDialog.vue'
import ConfirmDialog from '@/components/ConfirmDialog.vue'

const router = useRouter()
const showDrawer = ref(false)
const showSignInDialog = ref(false)
const showConfirmDialog = ref(false)
const tokenService = new TokenService()

function showLoginLogOut() {
  if (localStorage.getItem('token')) {
    showConfirmDialog.value = true
  } else {
    showSignInDialog.value = true
  }
}

function logout() {
  localStorage.removeItem('token')
  localStorage.removeItem('user')

  router.push('/')
}
</script>
