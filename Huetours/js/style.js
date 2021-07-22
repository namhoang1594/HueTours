$(document).ready(function () {
	$(function () {
		$('.title_faq').on('click', function (event) {
			event.preventDefault();
			var $this = $(this);
			if ($this.next().css('display') != 'block') {
				$('.content').slideUp(100);
				$('.icon_faq').removeClass('active_faq');
				$('.title_faq').removeClass('active_title');

				$this.addClass('active_title');
				$this.next().slideDown(100);
				$this.children('.icon_faq').addClass('active_faq');
			}
			else {
				$this.removeClass('active_title');
				$this.next().slideUp(100);
				$this.children('.icon_faq').removeClass('active_faq');
			}
		});
	});
}