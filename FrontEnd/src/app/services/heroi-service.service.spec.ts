import { TestBed } from '@angular/core/testing';
import { HeroiServiceService } from './heroi-service.service';

describe('HeroiServiceService', () => {
  let service: HeroiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HeroiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
