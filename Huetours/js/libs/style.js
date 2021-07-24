function onScroll(t) {
	var e = $(document).scrollTop();
	$(".list_title_section a").each(function () {
		var t = $(this),
			o = $(t.attr("href"));
		o.position().top <= e && o.position().top + o.height() > e ? ($(".list_title_section li a").removeClass("active_title_link"), t.addClass("active_title_link")) : t.removeClass("active_title_link")
	})
}
$(document).ready(function () {
	   $(function () {
		$(".title_faq").on("click", function (t) {
			t.preventDefault();
			var o = $(this);
			"block" != o.next().css("display") ? ($(".content").slideUp(100), $(".icon_faq").removeClass("active_faq"), $(".title_faq").removeClass("active_title"), o.addClass("active_title"), o.next().slideDown(100), o.children(".icon_faq").addClass("active_faq")) : (o.removeClass("active_title"), o.next().slideUp(100), o.children(".icon_faq").removeClass("active_faq"))
		})
	}), $(document).on("scroll", onScroll), $('.list_title_section a[href^="#"]').on("click", function (t) {
		t.preventDefault(), $(document).off("scroll"), $("a").each(function () {
			$(this).removeClass("active_title_link")
		}), $(this).addClass("active_title_link");
		var o = this.hash;
		$target = $(o), $offsetTop = $target.offset().top, $("html, body").stop().animate({
			scrollTop: $offsetTop
		}, 600, "swing", function () {
			$(document).on("scroll", onScroll)
		})
	})
});