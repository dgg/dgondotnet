/// <reference path="jquery-2.0.3.js" />
/// <reference path="jquery-ui-1.10.3.js" />
/// <reference path="handlebars.min.js" />

var DGON_DOTNET = DGON_DOTNET || {};

; (function ($, log, undefined) {
	DGON_DOTNET.ClientInteraction =
	{
		makeSortable: function (tableSelector, options) {
			options = optionsWithDefaults(options, {
				handleSelector: '.handle',
				sortSelector: '.data-sort'
			});

			var tbody = $(tableSelector + ' tbody');
			$(tbody).sortable({
				helper: maintainWidth,
				handle: options.handleSelector,
				stop: function (e, ui) {
					reorder(e.target.rows, options.sortSelector);
				}
			});
		},
		makeDeletable: function (tableSelector, options) {
			options = optionsWithDefaults(options, {
				deleteSelector: '.trash',
				deletedSelector: '.data-delete',
			});

			$(tableSelector).delegate(
				options.deleteSelector,
				'click',
				function (evt) {
					deleteRow(evt.target, options);
				});
		},
		addTemplatedRow: function (tableSelector, templateSelector, options) {
			options = optionsWithDefaults(options, {
				templateIndexer: 'NewIndex',
				indexSelector: '.data-index',
			});

			var last = calculateLast(tableSelector);

			var data = {};
			data[options.templateIndexer] = last.index;
			var instance = instantiateTemplate(templateSelector, data);

			last.$row.after(instance);
		}
	};
	function optionsWithDefaults(options, defaults) {
		if (typeof options === 'object') {
			options = $.extend(defaults, options);
		}
		else {
			options = defaults;
		}
		return options;
	}

	var maintainWidth = function (e, ui) {
		ui.children().each(function () {
			$(this).width($(this).width());
		});
		return ui;
	};

	function reorder(rows, sortSelector) {
		$(rows).each(function (index) {
			var $row = $(this);
			$row.find(sortSelector).val(index);
		});
	}
	
	function deleteRow(column, options) {
		$(column).parents('tr')
			.hide({
				complete: function () {
					var $row = $(this);
					$row.find(options.deletedSelector).val(true);
				}
			});
	}
	
	function calculateLast(tableSelector) {
		var last = { $row: null, index: 0 };
		$(tableSelector + ' tbody tr').each(function () {
			last.$row = $(this);
			last.index++;
		});
		return last;
	}
	
	function instantiateTemplate(templateSelector, data) {
		var template = Handlebars.compile($(templateSelector).html());
		return template(data);
	}

})(jQuery);