import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UrlShortnerService } from '../url-shortner.service';

@Component({
  selector: 'app-url-shortner',
  templateUrl: './url-shortner.component.html',
  styleUrls: ['./url-shortner.component.css']
})
export class UrlShortnerComponent implements OnInit, OnDestroy {
  title = 'LinkShortnerUI';
  public longUrl: string = "";
  public shortUrl: string = "";
  public isShowUrlShortner: boolean = false;
  private routeParameters: any;
  constructor(private route: ActivatedRoute, private urlShortnerService: UrlShortnerService) { }

  ngOnInit(): void {
    this.routeParameters = this.route.params.subscribe(params => {
      var id = params['id'];
      if (id) {
        this.redirectTo(id);
      }
      else {
        this.isShowUrlShortner = true;
      }
    });
  }

  shortenUrl() {
    this.urlShortnerService.getShortenedUrl(this.longUrl).subscribe(params => {
      this.shortUrl = location.origin + '/' + params.linkIdentifier;
    })
  }

  redirectTo(urlIdentifier: string) {
    this.urlShortnerService.getOriginalUrl(urlIdentifier).subscribe(params => {
      var fullUrl = params.originalLink;
      if (fullUrl.startsWith("http")) {
        window.location.href = params.originalLink;
      } else {
        window.location.href = "//" + params.originalLink;
      }

    })
  }
  ngOnDestroy() {
    this.routeParameters.unsubscribe();
  }
}
