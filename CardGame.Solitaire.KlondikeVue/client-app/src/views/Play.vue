<template>
	<div class="play">
		<Player playerName="judd" playerScore="10" person="{name='judd',score='10'}"></Player>
		<br />
		<div id="game-nav">
			<router-link to='/solitaire/klondike'>Play Klondike</router-link>
		</div>
		<router-view />
	</div>
</template>


<script>
// @ is an alias to /src
import Player from '@/components/Player.vue'

export default {
  name: 'play',
  components: {
    Player
  }
}
</script>
