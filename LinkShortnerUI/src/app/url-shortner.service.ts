import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Link } from './models/link';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UrlShortnerService {

  constructor(private http: HttpClient) { }

  getShortenedUrl(url: string): Observable<Link> {
    return this.http
      .post<Link>(`https://localhost:7088/Links`, { OriginalLink: url });
  }
  getOriginalUrl(identifier: string): Observable<Link> {
    return this.http
      .get<Link>(`https://localhost:7088/Links?identifier=${identifier}`);
  }
}
