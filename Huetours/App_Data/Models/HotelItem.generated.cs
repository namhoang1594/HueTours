//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.15.0
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	/// <summary>Hotel Item</summary>
	[PublishedModel("hotelItem")]
	public partial class HotelItem : PublishedContentModel, IContentBase
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		public new const string ModelTypeAlias = "hotelItem";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<HotelItem, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public HotelItem(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Hotel Images
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("hotelImages")]
		public virtual global::System.Collections.Generic.IEnumerable<global::Umbraco.Core.Models.MediaWithCrops> HotelImages => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Core.Models.MediaWithCrops>>("hotelImages");

		///<summary>
		/// Price
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("price")]
		public virtual string Price => this.Value<string>("price");

		///<summary>
		/// Thumbnail Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("thumbnailImage")]
		public virtual global::Umbraco.Core.Models.MediaWithCrops ThumbnailImage => this.Value<global::Umbraco.Core.Models.MediaWithCrops>("thumbnailImage");

		///<summary>
		/// Content
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("content")]
		public virtual global::System.Web.IHtmlString Content => global::Umbraco.Web.PublishedModels.ContentBase.GetContent(this);

		///<summary>
		/// Page Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("pageTitle")]
		public virtual string PageTitle => global::Umbraco.Web.PublishedModels.ContentBase.GetPageTitle(this);

		///<summary>
		/// Sub Page Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("subPageTitle")]
		public virtual string SubPageTitle => global::Umbraco.Web.PublishedModels.ContentBase.GetSubPageTitle(this);
	}
}
