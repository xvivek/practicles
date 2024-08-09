

def compounding():
    base_year = 2020
    principal=100
    rate =0.26
    numofyears =10
    year =1
    while year<numofyears:
        principal = principal * (rate+1)
        #print(f'{year:>3d} {principal:0.2f}')
        #print(f'{base_year + year:>4d} {principal:0.2f}')
        #print('{0:>3d} {1:0.2f}'.format(year,principal))
        print('%3d %0.2f'%(year,principal))
        year=year+1  
    
print(7/4)
print(7//4)

x=7
y=4
print(divmod(x,y))

x=7.4567987
print(round(x,3))

compounding()



