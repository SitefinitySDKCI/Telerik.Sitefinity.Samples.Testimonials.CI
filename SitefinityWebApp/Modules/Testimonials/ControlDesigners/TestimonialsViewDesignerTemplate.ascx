<%@ Register Assembly="Telerik.Sitefinity, Version=6.3.5000.0, Culture=neutral, PublicKeyToken=b28c218413bdf563" Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sf" %>
<sitefinity:FormManager ID="formManager" runat="server" />

<div class="sfContentViews">
	<div id="RotatorOptions">
		<div>
			<div id="groupSettingPageSelect">
					<ul class="sfTargetList">
						<li>
							<label for="Count" class="sfTxtLbl">Testimonials Count</label>
							<input type="text" id="Count" class="sfTxt" />
						</li>
						<li>
							<label for="DetailsPage" class="sfTxtLbl">Details Page</label>
							<sf:PageField ID="PageSelector" runat="server" WebServiceUrl="~/Sitefinity/Services/Pages/PagesService.svc/" DisplayMode="Write" />
						</li>
					</ul>
			</div>
		</div>
	</div>
</div>