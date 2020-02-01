<template>
	<div class="klondike">
		Current Game: Klondike
		<Game></Game>
	</div>
</template>

<script>
import Game from '../../components/klondike/Game.vue';

export default {
	name: 'klondike',
	components: {
		Game
	}
}
</script>