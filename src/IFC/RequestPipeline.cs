namespace IFC;

public static class RequestPipeline
{
    public static WebApplication AddRequestPipeline(this WebApplication request)
    {
        if (!request.Environment.IsDevelopment())
        {
            request.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            request.UseHsts();
        }

        request.UseHttpsRedirection();
        request.UseStaticFiles();
        // request.UseCookiePolicy();
        //request.UseRequestLocalization();
        //request.UseCors();
        request.UseRouting();
        request.UseAuthentication();
        request.UseAuthorization();
        request.UseSession();
        //request.UseResponseCompression();
        //request.UseResponseCaching();
        request.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        return request;
    }
}
